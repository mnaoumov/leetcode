using JetBrains.Annotations;

namespace LeetCode._6294_Difference_Between_Maximum_and_Minimum_Price_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-328/submissions/detail/878375511/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaxOutput(int n, int[][] edges, int[] price)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var result = 0L;

        Dfs(0, -1);

        return result;

        (long maxSumForFullPath, long maxSumForPathWithoutLeaf) Dfs(int node, int parent)
        {
            var skipNodeResult = 0L;
            var takeNodeResult = 0L;
            var nodePrice = price[node];

            foreach (var child in neighbors[node].Except(new[] { parent }))
            {
                var (maxSumForFullPath, maxSumForPathWithoutLeaf) = Dfs(child, node);
                skipNodeResult = Math.Max(skipNodeResult, maxSumForFullPath);
                takeNodeResult = Math.Max(takeNodeResult, nodePrice + maxSumForPathWithoutLeaf);
            }

            result = Math.Max(result, skipNodeResult);
            result = Math.Max(result, takeNodeResult);

            return (
                maxSumForFullPath: skipNodeResult + nodePrice,
                maxSumForPathWithoutLeaf: takeNodeResult
            );
        }
    }
}
