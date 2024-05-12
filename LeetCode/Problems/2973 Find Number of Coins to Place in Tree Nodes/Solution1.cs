using JetBrains.Annotations;

namespace LeetCode.Problems._2973_Find_Number_of_Coins_to_Place_in_Tree_Nodes;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-120/submissions/detail/1126735093/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

        List<int> Dfs(int node, int parent)
        {
            const int maxCount = 3;

            var pq = new PriorityQueue<int, int>();
            var nodeCost = cost[node];
            pq.Enqueue(nodeCost, nodeCost);

            var childNodes = adjNodes[node].Except(new[] { parent }).ToArray();

            foreach (var childNode in childNodes)
            {
                var subtreeNodeCosts = Dfs(childNode, node);

                foreach (var subtreeNodeCost in subtreeNodeCosts)
                {
                    pq.Enqueue(subtreeNodeCost, subtreeNodeCost);

                    if (pq.Count > maxCount)
                    {
                        pq.Dequeue();
                    }
                }
            }

            var subtreeCosts = new List<int>();

            while (pq.Count > 0)
            {
                subtreeCosts.Add(pq.Dequeue());
            }

            if (subtreeCosts.Count < maxCount)
            {
                ans[node] = 1;
            }
            else
            {
                var prod = subtreeCosts.Aggregate(1L, (a, b) => a * b);
                ans[node] = Math.Max(prod, 0L);
            }

            return subtreeCosts;
        }
    }
}
