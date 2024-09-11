using JetBrains.Annotations;
using LeetCode.Sql;

namespace LeetCode.Problems._1050_Actors_and_Directors_Who_Cooperated_At_Least_Three_Times;

[UsedImplicitly]
public class Tests : SelectSqlTestsBase<Tests>
{
    protected override bool IgnoreRowOrder => true;
}
