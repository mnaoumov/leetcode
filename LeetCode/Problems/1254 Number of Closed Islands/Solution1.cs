using JetBrains.Annotations;

namespace LeetCode.Problems._1254_Number_of_Closed_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/924028732/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ClosedIsland(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var connectedToBorderMap = new Dictionary<(int i, int j), bool>();
        var result = 0;
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != 0)
                {
                    continue;
                }

                if (connectedToBorderMap.ContainsKey((i, j)))
                {
                    continue;
                }

                if (!Dfs(i, j))
                {
                    result++;
                }
            }
        }

        return result;

        bool Dfs(int i, int j)
        {
            if (i < 0 || j < 0 || i >= m || j >= n)
            {
                return false;
            }

            if (connectedToBorderMap.TryGetValue((i, j), out var connectedToBorder))
            {
                return connectedToBorder;
            }

            if (grid[i][j] != 0)
            {
                return false;
            }

            connectedToBorder = i == 0 || i == m - 1 || j == 0 || j == n - 1;
            connectedToBorderMap[(i, j)] = connectedToBorder;

            foreach (var (di, dj) in directions)
            {
                connectedToBorder |= Dfs(i + di, j + dj);
            }

            connectedToBorderMap[(i, j)] = connectedToBorder;
            return connectedToBorder;
        }
    }
}
