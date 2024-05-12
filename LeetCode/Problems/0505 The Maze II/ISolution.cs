using JetBrains.Annotations;

namespace LeetCode.Problems._0505_The_Maze_II;

[PublicAPI]
public interface ISolution
{
    public int ShortestDistance(int[][] maze, int[] start, int[] destination);
}
