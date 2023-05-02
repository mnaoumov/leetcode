using System.Text.RegularExpressions;

namespace LeetCode;

public abstract class FunctionSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    protected override string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script)
    {
        var functionName = Regex.Match(script, @"CREATE FUNCTION (.+?)\(").Groups[1].Value;
        var command = db.Connection.CreateCommand();
        command.CommandText = $"DROP FUNCTION IF EXISTS dbo.{functionName}";
        command.ExecuteNonQuery();
        command.CommandText = script;
        command.ExecuteNonQuery();
        return $"SELECT dbo.{functionName}({testCase.Argument}) AS '{functionName}({testCase.Argument})'";
    }
}
