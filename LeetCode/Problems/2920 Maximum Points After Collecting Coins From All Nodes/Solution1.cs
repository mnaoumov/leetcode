using JetBrains.Annotations;

namespace LeetCode.Problems._2920_Maximum_Points_After_Collecting_Coins_From_All_Nodes;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-369/submissions/detail/1086516335/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaximumPoints(int[][] edges, int[] coins, int k)
    {
        var n = coins.Length;
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        return Dfs(0, -1, 0);

        int Dfs(int node, int parent, int halvesCount)
        {
            var nodeCoins = coins[node] >> halvesCount;
            var childNodes = adjNodes[node].Where(adjNode => adjNode != parent).ToArray();

            return Math.Max(
                nodeCoins - k + childNodes.Sum(childNode => Dfs(childNode, node, halvesCount)),
                nodeCoins / 2 + childNodes.Sum(childNode => Dfs(childNode, node, halvesCount + 1)));
        }
    }
}
