using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1795_Rearrange_Products_Table;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
