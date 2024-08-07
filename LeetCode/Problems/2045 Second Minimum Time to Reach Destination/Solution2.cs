using JetBrains.Annotations;

namespace LeetCode.Problems._2045_Second_Minimum_Time_to_Reach_Destination;

/// <summary>
/// https://leetcode.com/submissions/detail/1336722238/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

        var minVisitTimes = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        var nextAfterMinVisitTimes = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        var freq = new int[n + 1];

        var pq = new PriorityQueue<(int node, int visitTime), int>();
        pq.Enqueue((1, 0), 0);
        minVisitTimes[1] = 0;

        while (true)
        {
            var (node, visitTime) = pq.Dequeue();
            freq[node]++;

            if (freq[node] == 2 && node == n)
            {
                return visitTime;
            }

            var waitTime = visitTime / change % 2 == 0 ? 0 : change - visitTime % change;
            var nextVisitTime = visitTime + time + waitTime;

            foreach (var neighbor in adjNodes[node])
            {
                if (freq[neighbor] == 2)
                {
                    continue;
                }

                if (minVisitTimes[neighbor] > visitTime)
                {
                    nextAfterMinVisitTimes[neighbor] = minVisitTimes[neighbor];
                    minVisitTimes[neighbor] = visitTime;
                    pq.Enqueue((neighbor, nextVisitTime), nextVisitTime);
                }
                else if (nextAfterMinVisitTimes[neighbor] > visitTime && minVisitTimes[neighbor] != visitTime)
                {
                    nextAfterMinVisitTimes[neighbor] = visitTime;
                    pq.Enqueue((neighbor, nextVisitTime), nextVisitTime);
                }
            }
        }
    }
}
