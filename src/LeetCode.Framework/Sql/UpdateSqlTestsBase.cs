namespace LeetCode.Sql;

public abstract class UpdateSqlTestsBase<TSqlTests> : ModifyTableSqlTestsBase<TSqlTests> where TSqlTests : SqlTestsBase<TSqlTests>;
