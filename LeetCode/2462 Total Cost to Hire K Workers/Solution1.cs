using JetBrains.Annotations;

namespace LeetCode._2462_Total_Cost_to_Hire_K_Workers;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long TotalCost(int[] costs, int k, int candidates)
    {
        long result = 0;

        for (var i = 0; i < k; i++)
        {
            var firstBatch = costs.Select((cost, index) => (cost, index)).Where(x => x.cost != int.MaxValue).Take(candidates);
            var lastBatch = costs.Select((cost, index) => (cost, index)).Where(x => x.cost != int.MaxValue).TakeLast(candidates);

            var best = firstBatch.Concat(lastBatch).MinBy(x => x.cost);
            result += best.cost;
            costs[best.index] = int.MaxValue;
        }

        return result;
    }
}
