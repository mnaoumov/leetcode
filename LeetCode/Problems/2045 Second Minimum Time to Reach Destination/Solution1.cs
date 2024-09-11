using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2045_Second_Minimum_Time_to_Reach_Destination;

/// <summary>
/// https://leetcode.com/submissions/detail/1335632359/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int SecondMinimum(int n, int[][] edges, int time, int change)
    {
        var adjNodes = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[u].Add(v);
            adjNodes[v].Add(u);
        }

        var pq =new PriorityQueue<(int node, int visitTime), int>();
        pq.Enqueue((1, 0), 0);

        const int noTime = -1;
        var lastNodeFirstVisitTime = noTime;

        while (true)
        {
            var (node, visitTime) = pq.Dequeue();

            if (node == n)
            {
                if (lastNodeFirstVisitTime == noTime)
                {
                    lastNodeFirstVisitTime = visitTime;
                }
                else if (visitTime != lastNodeFirstVisitTime)
                {
                    return visitTime;
                }
            }

            var waitTime = visitTime / change % 2 == 0 ? 0 : change - visitTime % change;

            foreach (var adjNode in adjNodes[node])
            {
                var nextVisitTime = visitTime + time + waitTime;
                pq.Enqueue((adjNode, nextVisitTime), nextVisitTime);
            }
        }
    }
}
