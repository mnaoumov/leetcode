using JetBrains.Annotations;

namespace LeetCode._0695_Max_Area_of_Island;

/// <summary>
/// https://leetcode.com/submissions/detail/897950321/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        var result = 0;
        const int water = 0;

        var m = grid.Length;
        var n = grid[0].Length;
        var visited = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result = Math.Max(result, Dfs(i, j));
            }
        }

        return result;

        int Dfs(int i, int j)
        {
            if (i < 0 || j < 0 || i >= m || j >= n)
            {
                return 0;
            }

            if (grid[i][j] == water)
            {
                return 0;
            }

            if (visited[i, j])
            {
                return 0;
            }

            visited[i, j] = true;

            return 1 + Dfs(i + 1, j) + Dfs(i - 1, j) + Dfs(i, j + 1) + Dfs(i, j - 1);
        }
    }
}
