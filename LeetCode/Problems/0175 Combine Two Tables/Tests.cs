using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._0175_Combine_Two_Tables;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
