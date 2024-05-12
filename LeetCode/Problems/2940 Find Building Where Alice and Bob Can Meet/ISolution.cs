using JetBrains.Annotations;

namespace LeetCode._2940_Find_Building_Where_Alice_and_Bob_Can_Meet;

[PublicAPI]
public interface ISolution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries);
}
