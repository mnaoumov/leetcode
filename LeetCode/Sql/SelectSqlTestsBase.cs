namespace LeetCode;

public abstract class SelectSqlTestsBase<TSqlTests> : SqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>
{
    protected override string GetResultQuery(SqlDatabase db, SqlTestCase testCase, string script) => script;
}