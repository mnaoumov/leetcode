using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;

namespace LeetCode.Sql;

public abstract class SqlTestsBase<TSqlTests> : TestsBase where TSqlTests : SqlTestsBase<TSqlTests>
{
    // One instance per test run, as LocalDb advises: its template is built once and each test's database is cloned from it.
    // Its files go under the local application data folder rather than LocalDb's default, the temp folder: SQL Server
    // refuses a data file on a volume whose sectors are larger than 4 KB, and the temp folder may well sit on one.
    private static readonly Lazy<SqlInstance> Instance =
        new(() => new SqlInstance("LeetCodeSqlTests", _ => Task.CompletedTask, LocalDbDirectory));

    private static string LocalDbDirectory =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalDb",
            "LeetCodeSqlTests");

    [Test]
    [TestCaseSource(nameof(JoinedTestCases))]
    [Category("SQL")]
    public void Test(string solutionScriptPath, string testCaseFilePath)
    {
        var testCase = LoadTestCase<SqlTestCase>(testCaseFilePath);
        RunTestWithTimeout(testCase,
            cancellationToken => RunSqlTestAsync(solutionScriptPath, testCase, cancellationToken));
    }

    private async Task RunSqlTestAsync(string solutionScriptPath, SqlTestCase testCase,
        CancellationToken cancellationToken)
    {
        var db = await Instance.Value.Build(GetDatabaseName(solutionScriptPath, testCase)).ConfigureAwait(true);

        try
        {
            await RunSqlTestAsync(db.Connection, solutionScriptPath, testCase, cancellationToken).ConfigureAwait(true);
        }
        finally
        {
            await db.Delete().ConfigureAwait(true);
        }
    }

    /// <summary>
    /// A database name unique to the test, kept well under SQL Server's 128 characters: the problem folder, cut short,
    /// and a hash of the whole test.
    /// </summary>
    internal static string GetDatabaseName(string solutionScriptPath, TestCaseBase testCase)
    {
        ArgumentNullException.ThrowIfNull(testCase);

        var problemName = new FileInfo(solutionScriptPath).Directory!.Name;
        var key = $"{Path.GetFullPath(solutionScriptPath)}|{testCase.TestCaseName}";
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(key)))[..16];
        var prefix = new string(problemName.Where(char.IsAsciiLetterOrDigit).Take(40).ToArray());
        return $"{prefix}_{hash}";
    }

    private async Task RunSqlTestAsync(SqlConnection connection, string solutionScriptPath, SqlTestCase testCase,
        CancellationToken cancellationToken)
    {
        try
        {
            var problemTestCaseDirectory = GetProblemDirectory(typeof(TSqlTests));
            var setUpScript = await File.ReadAllTextAsync(Path.Combine(problemTestCaseDirectory!, "SetUp.sql"), cancellationToken).ConfigureAwait(true);
            await ExecuteNonQueryAsync(connection, setUpScript, cancellationToken).ConfigureAwait(true);
        }
#pragma warning disable CA1031
        catch (Exception e)
#pragma warning restore CA1031
        {
            Assert.Fail($"Error executing SetUp.sql\r\n{e}");
        }

        try
        {
            // ReSharper disable once UseAwaitUsing
            using var command = connection.CreateCommand();

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

                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(true);
                    command.Parameters.Clear();
                }
            }
        }
#pragma warning disable CA1031
        catch (Exception e)
#pragma warning restore CA1031
        {
            HandleException(e, "Error preparing test case data");
        }

        using var dt = new DataTable();

        try
        {
            var script = await File.ReadAllTextAsync(solutionScriptPath, cancellationToken).ConfigureAwait(true);

            // ReSharper disable once UseAwaitUsing
            using var command = await GetResultCommandAsync(connection, testCase, script, cancellationToken).ConfigureAwait(true);
            // ReSharper disable once UseAwaitUsing
            using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(true);
            dt.Load(reader);
        }
#pragma warning disable CA1031
        catch (Exception e)
#pragma warning restore CA1031
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

    protected static async Task ExecuteNonQueryAsync(SqlConnection connection, string commandText,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        // ReSharper disable once UseAwaitUsing
        using var command = connection.CreateCommand();
        command.CommandText = commandText;
        await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(true);
    }

    /// <summary>
    /// Quotes a name as a SQL Server identifier, so it is used as it is rather than parsed as SQL.
    /// </summary>
    protected static string QuoteIdentifier(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return $"[{name.Replace("]", "]]", StringComparison.Ordinal)}]";
    }

    protected static string FormatValue(object? value) => Convert.ToString(value, CultureInfo.InvariantCulture) ?? "NULL";

    protected virtual bool IgnoreRowOrder => false;

    /// <summary>
    /// Runs whatever the solution script must run first, and returns the command whose rows are its result.
    /// </summary>
    protected abstract Task<SqlCommand> GetResultCommandAsync(SqlConnection connection, SqlTestCase testCase,
        string script, CancellationToken cancellationToken);

#pragma warning disable CA1000
    public static IEnumerable<TestCaseData> JoinedTestCases
#pragma warning restore CA1000
    {
        get
        {
            const int argumentCount = 2;
            var testCaseFiles = GetProblemFiles(typeof(TSqlTests), "TestCase*.json");

            if (testCaseFiles.Length == 0)
            {
                yield return DiscoveryFailure("No test cases found", argumentCount);
                yield break;
            }

            var solutionScriptFiles = GetProblemFiles(typeof(TSqlTests), "Solution*.sql");

            if (solutionScriptFiles.Length == 0)
            {
                yield return DiscoveryFailure("No Solution*.sql found", argumentCount);
                yield break;
            }

            foreach (var solutionScriptFile in solutionScriptFiles)
            {
                foreach (var testCaseData in JoinScriptTestCases(solutionScriptFile, "--", testCaseFiles, argumentCount,
                             testCaseFile => [solutionScriptFile, testCaseFile]))
                {
                    yield return testCaseData;
                }
            }
        }
    }
}
