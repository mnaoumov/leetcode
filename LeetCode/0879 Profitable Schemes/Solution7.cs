using JetBrains.Annotations;

namespace LeetCode._0879_Profitable_Schemes;

/// <summary>
/// https://leetcode.com/submissions/detail/937652040/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        const int modulo = 1_000_000_007;
        var crimeCount = group.Length;

        var dp = new int?[crimeCount + 1, n + 1, minProfit + 1];

        return Dp(0, n, minProfit);

        int Dp(int crimeIndex, int peopleAvailable, int requiredProfit)
        {
            if (dp[crimeIndex, peopleAvailable, requiredProfit] is { } result)
            {
                return result;
            }


            if (crimeIndex == crimeCount)
            {
                return requiredProfit <= 0 ? 1 : 0;
            }

            result = Dp(crimeIndex + 1, peopleAvailable, requiredProfit);

            if (group[crimeIndex] <= peopleAvailable)
            {
                result = (result + Dp(crimeIndex + 1, peopleAvailable - group[crimeIndex],
                    Math.Max(0, requiredProfit - profit[crimeIndex]))) % modulo;
            }

            dp[crimeIndex, peopleAvailable, requiredProfit] = result;
            return result;
        }
    }
}
