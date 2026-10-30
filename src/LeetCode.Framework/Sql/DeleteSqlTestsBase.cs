namespace LeetCode.Sql;

public abstract class DeleteSqlTestsBase<TSqlTests> : ModifyTableSqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>;
