using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1264_Page_Recommendations;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
