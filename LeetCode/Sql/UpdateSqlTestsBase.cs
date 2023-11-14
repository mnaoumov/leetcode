using System.Text.RegularExpressions;

namespace LeetCode;

public abstract partial class UpdateSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    [GeneratedRegex("""
                    UPDATE (.+?)

                    """)]
    private static partial Regex UpdateTableRegex();

    protected override string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script)
    {
        var table = UpdateTableRegex().Match(script).Groups[1].Value;
        var command = db.Connection.CreateCommand();
        command.CommandText = script;
        command.ExecuteNonQuery();
        return $"SELECT * FROM dbo.{table}";
    }
}
