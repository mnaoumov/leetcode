using Microsoft.Data.SqlClient;

namespace LeetCode.Sql;

public abstract class SelectSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    protected override Task<SqlCommand> GetResultCommandAsync(SqlConnection connection, SqlTestCase testCase,
        string script, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var command = connection.CreateCommand();
        command.CommandText = script;
        return Task.FromResult(command);
    }
}
