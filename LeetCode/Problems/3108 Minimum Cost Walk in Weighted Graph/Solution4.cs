using JetBrains.Annotations;

namespace LeetCode._3108_Minimum_Cost_Walk_in_Weighted_Graph;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-392/submissions/detail/1225409468/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        var edgesMap = Enumerable.Range(0, n).Select(_ => new List<(int adjNode, int weight)>()).ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var w = edge[2];
            edgesMap[u].Add((v, w));
            edgesMap[v].Add((u, w));
        }

        var m = query.Length;
        var ans = new int[m];

        for (var i = 0; i < m; i++)
        {
            var s = query[i][0];
            var t = query[i][1];

            if (s == t)
            {
                ans[i] = 0;
                continue;
            }

            ans[i] = int.MaxValue;

            var queue = new Queue<(int node, int cost)>();
            queue.Enqueue((s, int.MaxValue));
            var visitedCosts = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

            while (queue.Count > 0)
            {
                var (node, cost) = queue.Dequeue();

                var skip = visitedCosts[node].Any(previousCost => (previousCost & cost) == previousCost);

                if (skip)
                {
                    continue;
                }

                visitedCosts[node].Add(cost);

                if (node == t)
                {
                    ans[i] = Math.Min(ans[i], cost);
                }

                foreach (var (adjNode, weight) in edgesMap[node])
                {
                    queue.Enqueue((adjNode, cost & weight));
                }
            }

            if (ans[i] == int.MaxValue)
            {
                ans[i] = -1;
            }
        }

        return ans;
    }
}
