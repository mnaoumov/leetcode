using Microsoft.Data.SqlClient;

namespace LeetCode.Sql;

public abstract class FunctionSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    // The functions in the database; the one the script creates is the one not there before it ran.
    private const string FunctionsQuery = "SELECT name FROM sys.objects WHERE type IN ('FN', 'IF', 'TF')";

    protected override async Task<SqlCommand> GetResultCommandAsync(SqlConnection connection, SqlTestCase testCase,
        string script, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentNullException.ThrowIfNull(testCase);

        var functionsBefore = await ReadFunctionsAsync(connection, cancellationToken).ConfigureAwait(true);
        await ExecuteNonQueryAsync(connection, script, cancellationToken).ConfigureAwait(true);
        var functionsAfter = await ReadFunctionsAsync(connection, cancellationToken).ConfigureAwait(true);
        var createdFunctions = functionsAfter.Except(functionsBefore, StringComparer.Ordinal).ToArray();

        if (createdFunctions.Length != 1)
        {
            throw new InvalidOperationException(
                $"The script must create exactly one function, but created {createdFunctions.Length}: {string.Join(", ", createdFunctions)}");
        }

        var functionName = createdFunctions[0];
        var command = connection.CreateCommand();
        // The argument goes in as a parameter; only the column name shows it, quoted as an identifier.
        command.CommandText = $"SELECT dbo.{QuoteIdentifier(functionName)}(@argument) AS {QuoteIdentifier($"{functionName}({FormatValue(testCase.Argument)})")}";
        command.Parameters.AddWithValue("@argument", testCase.Argument ?? DBNull.Value);
        return command;
    }

    private static async Task<List<string>> ReadFunctionsAsync(SqlConnection connection, CancellationToken cancellationToken)
    {
        // ReSharper disable once UseAwaitUsing
        using var command = connection.CreateCommand();
        command.CommandText = FunctionsQuery;
        // ReSharper disable once UseAwaitUsing
        using var reader = await command.ExecuteReaderAsync(cancellationToken).ConfigureAwait(true);
        var functions = new List<string>();

        while (await reader.ReadAsync(cancellationToken).ConfigureAwait(true))
        {
            functions.Add(reader.GetString(0));
        }

        return functions;
    }
}
