using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0502_IPO;

/// <summary>
/// https://leetcode.com/submissions/detail/208466670/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital)
    {
        var companyCapital = W;
        var n = Capital.Length;
        var projectsTakenIndices = new HashSet<int>();

        for (int i = 0; i < k; i++)
        {
            const int noProjectIndex = -1;
            var bestProjectIndex = noProjectIndex;
            var bestProfit = 0;
            for (int j = 0; j < n; j++)
            {
                if (projectsTakenIndices.Contains(j) || Capital[j] > companyCapital)
                {
                    continue;
                }

                var profit = Profits[j];

                if (profit > bestProfit)
                {
                    bestProfit = profit;
                    bestProjectIndex = j;
                }
            }

            if (bestProjectIndex == noProjectIndex)
            {
                break;
            }

            projectsTakenIndices.Add(bestProjectIndex);
            companyCapital += bestProfit;
        }

        return companyCapital;
    }
}
