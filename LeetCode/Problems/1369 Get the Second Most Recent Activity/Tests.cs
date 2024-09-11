using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1369_Get_the_Second_Most_Recent_Activity;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
