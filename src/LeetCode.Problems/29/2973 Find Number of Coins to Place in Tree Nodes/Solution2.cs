namespace LeetCode.Problems._2973_Find_Number_of_Coins_to_Place_in_Tree_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/1126746131/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long[] PlacedCoins(int[][] edges, int[] cost)
    {
        var n = edges.Length + 1;
        var ans = new long[n];

        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            adjNodes[a].Add(b);
            adjNodes[b].Add(a);
        }

        Dfs(0, -1);

        return ans;

        (List<int> maxSubtreeCosts, List<int> minSubtreeCosts) Dfs(int node, int parent)
        {
            const int maxSubtreeCostCount = 3;
            const int minSubtreeCostCount = 2;

            var maxSubtreeCostsPq = new PriorityQueue<int, int>();
            var minSubtreeCostsPq = new PriorityQueue<int, int>();
            var nodeCost = cost[node];
            maxSubtreeCostsPq.Enqueue(nodeCost, nodeCost);

            var childNodes = adjNodes[node].Except(new[] { parent }).ToArray();

            foreach (var childNode in childNodes)
            {
                var (maxChildSubtreeCosts, minChildSubtreeCosts) = Dfs(childNode, node);

                foreach (var subtreeNodeCost in maxChildSubtreeCosts.Concat(minChildSubtreeCosts))
                {
                    maxSubtreeCostsPq.Enqueue(subtreeNodeCost, subtreeNodeCost);
                    minSubtreeCostsPq.Enqueue(subtreeNodeCost, -subtreeNodeCost);

                    if (maxSubtreeCostsPq.Count > maxSubtreeCostCount)
                    {
                        maxSubtreeCostsPq.Dequeue();
                    }

                    if (minSubtreeCostsPq.Count > minSubtreeCostCount)
                    {
                        minSubtreeCostsPq.Dequeue();
                    }
                }
            }

            var maxSubtreeCosts = new List<int>();
            var minSubtreeCosts = new List<int>();

            while (maxSubtreeCostsPq.Count > 0)
            {
                maxSubtreeCosts.Add(maxSubtreeCostsPq.Dequeue());
            }

            while (minSubtreeCostsPq.Count > 0)
            {
                minSubtreeCosts.Add(minSubtreeCostsPq.Dequeue());
            }

            if (maxSubtreeCosts.Count < maxSubtreeCostCount)
            {
                ans[node] = 1;
            }
            else
            {
                var maxProd = 1L * maxSubtreeCosts[0] * maxSubtreeCosts[1] * maxSubtreeCosts[2];
                var minProd = 1L * minSubtreeCosts[0] * minSubtreeCosts[1] * maxSubtreeCosts[2];

                ans[node] = new[] { maxProd, minProd, 0 }.Max();
            }

            return (maxSubtreeCosts, minSubtreeCosts);
        }
    }
}
