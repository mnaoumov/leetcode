using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1501_Countries_You_Can_Safely_Invest_In;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
