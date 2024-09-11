using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._0185_Department_Top_Three_Salaries;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
