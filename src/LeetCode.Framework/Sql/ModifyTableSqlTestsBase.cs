using Microsoft.Data.SqlClient;

namespace LeetCode.Sql;

/// <summary>
/// A solution that changes a table (a DELETE, an UPDATE): it is run, and its result is that table's rows afterwards.
/// </summary>
public abstract class ModifyTableSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    protected override async Task<SqlCommand> GetResultCommandAsync(SqlConnection connection, SqlTestCase testCase,
        string script, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var table = GetModifiedTable(testCase);
        await ExecuteNonQueryAsync(connection, script, cancellationToken).ConfigureAwait(true);
        var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM dbo.{QuoteIdentifier(table)}";
        return command;
    }

    /// <summary>
    /// The table the result is read from, taken from the test case rather than parsed out of the script:
    /// its only table, or else the one whose columns are the output's.
    /// </summary>
    internal static string GetModifiedTable(SqlTestCase testCase)
    {
        ArgumentNullException.ThrowIfNull(testCase);

        if (testCase.Headers.Count == 1)
        {
            return testCase.Headers.Keys.Single();
        }

        var candidates = testCase.Headers
            .Where(table => table.Value.SequenceEqual(testCase.Output.Headers, StringComparer.OrdinalIgnoreCase))
            .Select(table => table.Key)
            .ToArray();

        return candidates.Length == 1
            ? candidates[0]
            : throw new InvalidOperationException(
                $"Cannot tell which table the solution changes: {candidates.Length} of the test case's tables " +
                $"({string.Join(", ", testCase.Headers.Keys)}) have the output's columns");
    }
}
