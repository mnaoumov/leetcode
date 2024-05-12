using JetBrains.Annotations;

namespace LeetCode._1293_Shortest_Path_in_a_Grid_with_Obstacles_Elimination;

[PublicAPI]
public interface ISolution
{
    public int ShortestPath(int[][] grid, int k);
}
