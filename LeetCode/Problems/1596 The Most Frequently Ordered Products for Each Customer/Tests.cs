using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1596_The_Most_Frequently_Ordered_Products_for_Each_Customer;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
