using JetBrains.Annotations;

namespace LeetCode.Problems._3108_Minimum_Cost_Walk_in_Weighted_Graph;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-392/submissions/detail/1225398119/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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
            ans[i] = int.MaxValue;

            var queue = new Queue<(int node, int cost)>();
            queue.Enqueue((s, int.MaxValue));
            var visited = new HashSet<(int node, int cost)>();

            while (queue.Count > 0)
            {
                var (node, cost) = queue.Dequeue();

                if (!visited.Add((node, cost)))
                {
                    continue;
                }

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
