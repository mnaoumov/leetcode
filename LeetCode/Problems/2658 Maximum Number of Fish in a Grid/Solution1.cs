using JetBrains.Annotations;

namespace LeetCode._2658_Maximum_Number_of_Fish_in_a_Grid;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-103/submissions/detail/941594456/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaxFish(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int land = 0;
        var ans = 0;
        var seen = new bool[m, n];
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (seen[i, j])
                {
                    continue;
                }

                if (grid[i][j] == land)
                {
                    seen[i, j] = true;
                    continue;
                }

                ans = Math.Max(ans, Dfs(i, j));
            }
        }

        return ans;

        int Dfs(int i, int j)
        {
            seen[i, j] = true;

            if (grid[i][j] == land)
            {
                return 0;
            }

            var ans2 = grid[i][j];

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                {
                    continue;
                }

                if (seen[nextI, nextJ])
                {
                    continue;
                }

                ans2 += Dfs(nextI, nextJ);
            }

            return ans2;
        }
    }
}
