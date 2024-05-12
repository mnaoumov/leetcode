using JetBrains.Annotations;

namespace LeetCode.Problems._0499_The_Maze_III;

[PublicAPI]
public interface ISolution
{
    public string? FindShortestWay(int[][] maze, int[] ball, int[] hole);
}
