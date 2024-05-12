using JetBrains.Annotations;

namespace LeetCode._0733_Flood_Fill;

/// <summary>
/// https://leetcode.com/submissions/detail/923849172/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var m = image.Length;
        var n = image[0].Length;

        var result = image.Select(row => row.ToArray()).ToArray();

        var startingColor = image[sr][sc];

        var visited = new bool[m, n];

        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        Dfs(sr, sc);

        return result;

        void Dfs(int row, int column)
        {
            if (row < 0 || column < 0 || row >= m || column >= n)
            {
                return;
            }

            if (visited[row, column])
            {
                return;
            }

            visited[row, column] = true;

            if (result[row][column] != startingColor)
            {
                return;
            }

            result[row][column] = color;

            foreach (var (dRow, dColumn) in directions)
            {
                Dfs(row + dRow, column + dColumn);
            }
        }
    }
}
