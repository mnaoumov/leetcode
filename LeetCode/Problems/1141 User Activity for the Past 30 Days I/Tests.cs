using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1141_User_Activity_for_the_Past_30_Days_I;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
