using JetBrains.Annotations;

namespace LeetCode._0879_Profitable_Schemes;

/// <summary>
/// https://leetcode.com/submissions/detail/937647551/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    private const int Mod = 1000000007;
    private readonly int[,,] _memo = new int[101, 101, 101];

    private int Find(int pos, int count, int profit, int n, int minProfit, IReadOnlyList<int> group, IReadOnlyList<int> profits)
    {
        if (pos == group.Count)
        {
            // If profit exceeds the minimum required; it's a profitable scheme.
            return profit >= minProfit ? 1 : 0;
        }

        if (_memo[pos, count, profit] != -1)
        {
            // Repeated subproblem, return the stored answer.
            return _memo[pos, count, profit];
        }

        // Ways to get a profitable scheme without this crime.
        var totalWays = Find(pos + 1, count, profit, n, minProfit, group, profits);
        if (count + group[pos] <= n)
        {
            // Adding ways to get profitable schemes, including this crime.
            totalWays += Find(pos + 1, count + group[pos], Math.Min(minProfit, profit + profits[pos]), n, minProfit, group, profits);
        }

        return _memo[pos, count, profit] = totalWays % Mod;
    }

    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        // Initializing all states as -1.
        for (var i = 0; i <= group.Length; i++)
        {
            for (var j = 0; j <= n; j++)
            {
                for (var k = 0; k < 101; k++)
                {
                    _memo[i, j, k] = -1;
                }
            }
        }

        return Find(0, 0, 0, n, minProfit, group, profit);
    }
}
