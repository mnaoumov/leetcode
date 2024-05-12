using JetBrains.Annotations;

namespace LeetCode.Problems._0808_Soup_Servings;

/// <summary>
/// https://leetcode.com/submissions/detail/1074025029/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution4 : ISolution
{
    public double SoupServings(int n)
    {
        var m = (n + 24) / 25;

        const int aMode = 0;
        const int abMode = 1;
        var modes = new[] { aMode, abMode };

        var dp = new double[5, m + 1, 2];
        dp[0, 0, abMode] = 1;

        for (var j = 1; j <= m; j++)
        {
            dp[0, j, aMode] = 1;
        }

        for (var i = 1; i <= m; i++)
        {
            for (var j = 0; j <= m; j++)
            {
                foreach (var mode in modes)
                {
                    for (var k = 4; k >= 1; k--)
                    {
                        dp[k, j, mode] = dp[k - 1, j, mode];
                    }

                    dp[0, j, mode] = 0;
                }
            }

            for (var j = 1; j <= m; j++)
            {
                for (var di = 1; di <= 4; di++)
                {
                    var dj = 4 - di;
                    var prevJ = Math.Max(0, j - dj);

                    foreach (var mode in modes)
                    {
                        dp[0, j, mode] += 0.25 * dp[Math.Min(di, i), prevJ, mode];
                    }
                }
            }
        }

        return dp[0, m, aMode] + 0.5 * dp[0, m, abMode];
    }
}
