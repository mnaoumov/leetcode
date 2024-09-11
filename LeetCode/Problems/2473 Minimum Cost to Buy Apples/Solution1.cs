using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2473_Minimum_Cost_to_Buy_Apples;

/// <summary>
/// https://leetcode.com/submissions/detail/875048152/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long[] MinCost(int n, int[][] roads, int[] appleCost, int k)
    {
        var minPathCosts = new Dictionary<(int city1, int city2), long>();

        foreach (var road in roads)
        {
            minPathCosts[(road[0], road[1])] = road[2];
            minPathCosts[(road[1], road[0])] = road[2];
        }

        var result = new long[n];

        for (var i = 1; i <= n; i++)
        {
            minPathCosts[(i, i)] = 0;
            result[i - 1] = appleCost[i - 1];
        }

        for (var middleCity = 1; middleCity <= n; middleCity++)
        {
            for (var city1 = 1; city1 <= n; city1++)
            {
                for (var city2 = 1; city2 <= n; city2++)
                {
                    if (!minPathCosts.TryGetValue((city1, middleCity), out var cost1) ||
                        !minPathCosts.TryGetValue((city2, middleCity), out var cost2))
                    {
                        continue;
                    }

                    var combinedCost = cost1 + cost2;

                    if (minPathCosts.TryGetValue((city1, city2), out var currentCost) && currentCost < combinedCost)
                    {
                        continue;
                    }

                    minPathCosts[(city1, city2)] = combinedCost;
                    minPathCosts[(city2, city1)] = combinedCost;
                    result[city1 - 1] = Math.Min(result[city1 - 1],
                        appleCost[city2 - 1] + combinedCost * (k + 1));
                }
            }
        }

        return result;
    }
}
