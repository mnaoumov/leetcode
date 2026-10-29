using System.Text.RegularExpressions;

namespace LeetCode.Sql;

public abstract partial class FunctionSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    [GeneratedRegex(@"CREATE FUNCTION (.+?)\(")]
    private static partial Regex CreateFunctionRegex();

    protected override string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script)
    {
        var functionName = CreateFunctionRegex().Match(script).Groups[1].Value;
        var command = db.Connection.CreateCommand();
        command.CommandText = $"DROP FUNCTION IF EXISTS dbo.{functionName}";
        command.ExecuteNonQuery();
        command.CommandText = script;
        command.ExecuteNonQuery();
        return $"SELECT dbo.{functionName}({testCase.Argument}) AS '{functionName}({testCase.Argument})'";
    }
}
