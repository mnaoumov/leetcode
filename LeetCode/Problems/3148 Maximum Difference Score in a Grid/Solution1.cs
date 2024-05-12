using JetBrains.Annotations;

namespace LeetCode.Problems._3148_Maximum_Difference_Score_in_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-397/submissions/detail/1255701707/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxScore(IList<IList<int>> grid)
    {
        var m = grid.Count;
        var n = grid[0].Count;

        var ans = int.MinValue;

        var dp = new int[m, n];

        for (var i = m - 1; i >= 0; i--)
        {
            for (var j = n - 1; j >= 0; j--)
            {
                if (i == m - 1 && j == n - 1)
                {
                    continue;
                }

                dp[i, j] = int.MinValue;

                for (var l = j + 1; l < n; l++)
                {
                    dp[i, j] = Math.Max(dp[i, j], grid[i][l] - grid[i][j] + Math.Max(0, dp[i, l]));
                }

                for (var k = i + 1; k < m; k++)
                {
                    dp[i, j] = Math.Max(dp[i, j], grid[k][j] - grid[i][j] + Math.Max(0, dp[k, j]));
                }

                ans = Math.Max(ans, dp[i, j]);
            }
        }

        return ans;
    }
}
