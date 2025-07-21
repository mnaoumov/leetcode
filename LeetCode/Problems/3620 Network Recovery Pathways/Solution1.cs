namespace LeetCode.Problems._3620_Network_Recovery_Pathways;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-161/problems/network-recovery-pathways/submissions/1703662409/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int FindMaxPathScore(int[][] edges, bool[] online, long k)
    {
        var n = online.Length;
        var edgesObjs = edges
            .Select(e => new Edge(e[0], e[1], e[2]))
            .ToArray();
        var edgesGroupedByFromNode = edgesObjs.Where(e => online[e.To]).GroupBy(e => e.From).ToDictionary(g => g.Key, g => g.ToArray());

        var ans = -1;

        var queue = new Queue<(int node, int totalCost, int minEdgeCost)>();
        queue.Enqueue((0, 0, int.MaxValue));

        while (queue.Count > 0)
        {
            var (node, totalCost, minEdgeCost) = queue.Dequeue();

            if (node == n - 1)
            {
                ans = Math.Max(ans, minEdgeCost);
                continue;
            }

            foreach (var edge in edgesGroupedByFromNode[node])
            {
                var nextTotalCost = totalCost + edge.Cost;

                if (nextTotalCost > k)
                {
                    continue;
                }

                queue.Enqueue((edge.To, nextTotalCost, Math.Min(minEdgeCost, edge.Cost)));
            }
        }

        return ans;
    }

    private record Edge(int From, int To, int Cost);
}
