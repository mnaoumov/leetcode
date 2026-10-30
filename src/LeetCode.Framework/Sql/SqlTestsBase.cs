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

        // Cloning the database and dropping it are outside the budget: they are LocalDb's file work, not the test's,
        // and on a loaded machine either can take most of the 30 seconds by itself.
        var databaseName = GetDatabaseName(solutionScriptPath, testCase);
        var db = RetryOnceAsync(() => Instance.Value.Build(databaseName), IsCloneNotYetAccessible).GetAwaiter()
            .GetResult();

        try
        {
            RunTestWithTimeout(testCase,
                cancellationToken => RunSqlTestAsync(db.Connection, solutionScriptPath, testCase, cancellationToken));
        }
        finally
        {
            db.Delete().GetAwaiter().GetResult();
        }
    }

    /// <summary>
    /// Runs the action, and runs it once more if its first failure is one <paramref name="shouldRetry"/> accepts.
    /// </summary>
    internal static async Task<T> RetryOnceAsync<T>(Func<Task<T>> action, Func<Exception, bool> shouldRetry)
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentNullException.ThrowIfNull(shouldRetry);

        try
        {
            return await action().ConfigureAwait(false);
        }
        catch (Exception e) when (shouldRetry(e))
        {
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            return await action().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Error 5011 on the <c>set read_write</c> straight after LocalDb attaches a clone: on a loaded machine the attached
    /// database is now and then not yet accessible. Building it again takes it offline, copies the template over it and
    /// brings it back online.
    /// </summary>
    private static bool IsCloneNotYetAccessible(Exception exception)
    {
        for (var e = exception; e != null; e = e.InnerException)
        {
            if (e is SqlException { Number: 5011 })
            {
                return true;
            }
        }

        return false;
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

        // NUnit's equivalence compares every row with every other, which took half a minute on 1,454 rows, so both
        // sides are put in one order instead and compared in it.
        if (IgnoreRowOrder)
        {
            actualData = OrderRows(actualData);
            expectedData = OrderRows(expectedData);
        }

        AssertCollectionEqualWithDetails(actualData, expectedData);
    }

    internal static object?[][] OrderRows(IEnumerable<object?[]> rows) => [.. rows.Order(RowComparer.Instance)];

    /// <summary>
    /// Orders result rows column by column: nulls first, numbers by value whatever their type, anything else by its
    /// invariant text.
    /// </summary>
    private sealed class RowComparer : IComparer<object?[]>
    {
        public static readonly RowComparer Instance = new();

        public int Compare(object?[]? x, object?[]? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            for (var i = 0; i < Math.Min(x.Length, y.Length); i++)
            {
                var result = CompareValues(x[i], y[i]);
                if (result != 0)
                {
                    return result;
                }
            }

            return x.Length.CompareTo(y.Length);
        }

        private static int CompareValues(object? x, object? y)
        {
            var xIsNull = x is null or DBNull;
            var yIsNull = y is null or DBNull;
            if (xIsNull || yIsNull)
            {
                return yIsNull.CompareTo(xIsNull);
            }

            if (IsNumber(x) && IsNumber(y))
            {
                return Convert.ToDouble(x, CultureInfo.InvariantCulture)
                    .CompareTo(Convert.ToDouble(y, CultureInfo.InvariantCulture));
            }

            return string.CompareOrdinal(FormatValue(x), FormatValue(y));
        }

        private static bool IsNumber(object? value) =>
            value is sbyte or byte or short or ushort or int or uint or long or ulong or float or double or decimal;
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
