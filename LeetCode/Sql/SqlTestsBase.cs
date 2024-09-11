using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace LeetCode.Sql;

public abstract partial class SqlTestsBase<TSqlTests> : TestsBase where TSqlTests : SqlTestsBase<TSqlTests>
{
    [GeneratedRegex("-- SkipSolution: (.+)")]
    private static partial Regex SkipSolutionRegex();

    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("SQL")]
    public void Test(string solutionScriptPath, SqlTestCase testCase)
    {
        RunTestWithStackAndTimeoutChecks(testCase,
            () => RunSqlTestAsync(solutionScriptPath, testCase).GetAwaiter().GetResult());
    }

    private async Task RunSqlTestAsync(string solutionScriptPath, SqlTestCase testCase)
    {
        var sqlInstance = new SqlInstance("LeetCodeSqlTests", _ => Task.CompletedTask);
        var dbName = $"{new FileInfo(solutionScriptPath).Directory!.Name} - {Path.GetFileNameWithoutExtension(solutionScriptPath)} - {testCase.TestCaseName}";
        dbName = string.Join("_", dbName.Split(Path.GetInvalidFileNameChars()));

        var db = await sqlInstance.Build(dbName);
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
            HandleException(e, "Error preparing test case data");
        }

        DataTable dt = null!;

        try
        {
            var script = await File.ReadAllTextAsync(solutionScriptPath);

            command.CommandText = GetResultQuery(db, testCase, script);
            await using var reader = await command.ExecuteReaderAsync();
            dt = new DataTable();
            dt.Load(reader);
        }
        catch (Exception e)
        {
            HandleException(e, "Error getting solution execution result");
        }

        AssertCollectionEqualWithDetails(dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName),
            testCase.Output.Headers);

        var actualData = dt.Rows.Cast<DataRow>().Select(row => row.ItemArray).ToArray();
        dt.Rows.Clear();

        for (var rowIndex = 0; rowIndex < testCase.Output.Values.Length; rowIndex++)
        {
            var expectedRow = testCase.Output.Values[rowIndex];
            dt.LoadDataRow(expectedRow, true);

            for (var columnIndex = 0; columnIndex < expectedRow.Length; columnIndex++)
            {
                if (expectedRow[columnIndex] == null)
                {
                    continue;
                }

                var actualType = dt.Columns[columnIndex].DataType;
                var expectedType = expectedRow[columnIndex]!.GetType();

                if (actualType == typeof(DateTime))
                {
                    actualType = typeof(string);
                }

                if (actualType == expectedType)
                {
                    continue;
                }

                if (actualType == typeof(string) || expectedType == typeof(string))
                {
                    Assert.Fail($"Row {rowIndex}, Column {columnIndex}. Expected data type {expectedType}, but was {actualType}");
                }
            }
        }

        var expectedData = dt.Rows.Cast<DataRow>().Select(row => row.ItemArray).ToArray();

        if (IgnoreRowOrder)
        {
            AssertCollectionEquivalentWithDetails(actualData, expectedData);
        }
        else
        {
            AssertCollectionEqualWithDetails(actualData, expectedData);
        }
    }

    private static void HandleException(Exception e, string message)
    {
        if (e is SqlException sqlException)
        {
            Assert.Fail($"{message}\r\nLine Number: {sqlException.LineNumber}\r\n{e}");
        }
        else
        {
            Assert.Fail($"{message}\r\n{e}");
        }
    }

    protected virtual bool IgnoreRowOrder => false;

    protected abstract string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script);

    public static IEnumerable<TestCaseData> JoinedTestCases
    {
        get
        {
            var testCases = GetTestCases<TSqlTests, SqlTestCase>();
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TSqlTests));
            var solutionScriptFiles = problemTestCaseDirectory == null
                ? Array.Empty<string>()
                : Directory.GetFiles(problemTestCaseDirectory, "Solution*.sql");

            if (solutionScriptFiles.Length == 0)
            {
                Assert.Fail("No Solution*.sql found");
            }

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                var solutionName = Path.GetFileNameWithoutExtension(solutionScriptFile);
                var firstLine = File.ReadLines(solutionScriptFile).First();
                var skipSolutionReason = SkipSolutionRegex().Match(firstLine).Groups[1].Value;

                foreach (var testCase in testCases)
                {
                    var testCaseData = new TestCaseData(solutionScriptFile, testCase).SetName($"{solutionName}: {testCase.TestCaseName}");

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
