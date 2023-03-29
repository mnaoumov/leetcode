using System.Text.RegularExpressions;

namespace LeetCode;

public abstract class UpdateSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    protected override string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script)
    {
        var updateTable = Regex.Match(script, @"UPDATE (.+?)\n").Groups[1].Value;
        var command = db.Connection.CreateCommand();
        command.CommandText = script;
        command.ExecuteNonQuery();
        return $"SELECT * FROM dbo.{updateTable}";
    }
}