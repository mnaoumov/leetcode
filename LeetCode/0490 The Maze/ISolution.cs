using JetBrains.Annotations;

namespace LeetCode._0490_The_Maze;

[PublicAPI]
public interface ISolution
{
    public bool HasPath(int[][] maze, int[] start, int[] destination);
}
