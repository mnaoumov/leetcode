using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1193_Monthly_Transactions_I;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
