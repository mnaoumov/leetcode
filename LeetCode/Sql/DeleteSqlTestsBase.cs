using System.Text.RegularExpressions;

namespace LeetCode;

public abstract partial class DeleteSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    [GeneratedRegex(@"DELETE
FROM (.+?)
")]
    private static partial Regex DeleteTableRegex();

    protected override string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script)
    {
        var table = DeleteTableRegex().Match(script).Groups[1].Value;
        var command = db.Connection.CreateCommand();
        command.CommandText = script;
        command.ExecuteNonQuery();
        return $"SELECT * FROM dbo.{table}";
    }
}
