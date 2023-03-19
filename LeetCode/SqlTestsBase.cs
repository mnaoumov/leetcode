﻿using System.Data;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace LeetCode;

public abstract class SqlTestsBase<TSqlTests> : TestsBase where TSqlTests : SqlTestsBase<TSqlTests>
{
    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("SQL")]
    public void Test(string solutionScriptPath, SqlTestCase testCase)
    {
        RunTestWithStackAndTimeoutChecks(testCase,
            () => RunSqlTestAsync(solutionScriptPath, testCase).GetAwaiter().GetResult());
    }

    private static async Task RunSqlTestAsync(string solutionScriptPath, SqlTestCase testCase)
    {
        var sqlInstance = new SqlInstance(
    $"{typeof(TSqlTests).Namespace}_{Path.GetFileNameWithoutExtension(solutionScriptPath)}_{testCase.TestCaseName}",
    _ => Task.CompletedTask);

        var db = await sqlInstance.Build();
        await using var command = db.Connection.CreateCommand();

        try
        {
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TSqlTests));
            command.CommandText = await File.ReadAllTextAsync($@"{problemTestCaseDirectory}\SetUp.sql");
            await command.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            Assert.Fail($"Error executing SetUp.sql\r\n{e}");
        }

        try
        {
            foreach (var tableName in testCase.Rows.Keys)
            {
                var columnNames = testCase.Headers[tableName];
                var columnNamesStr = string.Join(",", columnNames);
                foreach (var row in testCase.Rows[tableName])
                {
                    var parametersStr = string.Join(",", Enumerable.Range(0, row.Length).Select(i => $"@p{i}"));
                    command.CommandText = $"INSERT INTO {tableName}({columnNamesStr}) VALUES({parametersStr})";
                    for (var i = 0; i < row.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@p{i}", row[i] ?? DBNull.Value);
                    }

                    await command.ExecuteNonQueryAsync();
                    command.Parameters.Clear();
                }
            }
        }
        catch (Exception e)
        {
            Assert.Fail($"Error preparing test case data\r\n{e}");
        }

        DataTable dt = null!;

        try
        {
            var script = await File.ReadAllTextAsync(solutionScriptPath);

            var functionName = Regex.Match(script, @"CREATE FUNCTION (.+?)\(").Groups[1].Value;

            if (!string.IsNullOrEmpty(functionName))
            {
                command.CommandText = $"DROP FUNCTION IF EXISTS dbo.{functionName}";
                command.ExecuteNonQuery();
                command.CommandText = script;
                command.ExecuteNonQuery();
                command.CommandText = $"SELECT dbo.{functionName}({testCase.Argument}) AS '{functionName}({testCase.Argument})'";
            }
            else
            {
                command.CommandText = script;
            }

            await using var reader = await command.ExecuteReaderAsync();
            dt = new DataTable();
            dt.Load(reader);
        }
        catch (Exception e)
        {
            Assert.Fail($"Error getting solution execution result\r\n{e}");
        }

        AssertCollectionEqualWithDetails(dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName),
            testCase.Output.Headers);

        var actualData = dt.Rows.Cast<DataRow>().Select(row => row.ItemArray).ToArray();
        dt.Rows.Clear();
        foreach (var expectedRow in testCase.Output.Values)
        {
            dt.LoadDataRow(expectedRow, true);
        }

        var expectedData = dt.Rows.Cast<DataRow>().Select(row => row.ItemArray).ToArray();

        if (testCase.IgnoreRowOrder)
        {
            AssertCollectionEquivalentWithDetails(actualData, expectedData);
        }
        else
        {
            AssertCollectionEqualWithDetails(actualData, expectedData);
        }
    }

    public static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TSqlTests));

            if (problemTestCaseDirectory == null)
            {
                yield break;
            }

            var testCaseFiles = Directory.GetFiles(problemTestCaseDirectory, "TestCase*.json");
            var solutionScriptFiles = Directory.GetFiles(problemTestCaseDirectory, "Solution*.sql");

            var testCases = testCaseFiles.Select(FromJson<SqlTestCase>).ToArray();

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
                var firstLine = File.ReadLines(solutionScriptFile).First();
                var skipSolutionReason = Regex.Match(firstLine, "-- SkipSolution: (.+)").Groups[1].Value;

                foreach (var testCase in testCases)
                {
                    var testCaseData = new TestCaseData(solutionScriptFile, testCase).SetName($@"{solutionName}: {testCase.TestCaseName}");

                    if (!string.IsNullOrEmpty(skipSolutionReason))
                    {
                        testCaseData.Explicit(skipSolutionReason);
                    }

                    yield return testCaseData;
                }
            }
        }
    }
}