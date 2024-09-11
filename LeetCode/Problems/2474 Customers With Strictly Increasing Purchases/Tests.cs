using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._2474_Customers_With_Strictly_Increasing_Purchases;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
