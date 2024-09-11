using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._0197_Rising_Temperature;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
