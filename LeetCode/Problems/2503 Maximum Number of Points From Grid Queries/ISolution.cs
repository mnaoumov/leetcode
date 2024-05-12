using JetBrains.Annotations;

namespace LeetCode.Problems._2503_Maximum_Number_of_Points_From_Grid_Queries;

[PublicAPI]
public interface ISolution
{
    public int[] MaxPoints(int[][] grid, int[] queries);
}
