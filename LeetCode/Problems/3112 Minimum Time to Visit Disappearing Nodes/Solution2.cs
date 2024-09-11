using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3112_Minimum_Time_to_Visit_Disappearing_Nodes;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-128/submissions/detail/1231262476/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] MinimumTime(int n, int[][] edges, int[] disappear)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<(int adjNode, int length)>()).ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var length = edge[2];
            adjNodes[u].Add((adjNode: v, length));
            adjNodes[v].Add((adjNode: u, length));
        }

        var ans = Enumerable.Repeat(int.MaxValue, n).ToArray();

        var queue = new Queue<(int node, int time)>();
        queue.Enqueue((0, 0));

        while (queue.Count > 0)
        {
            var (node, time) = queue.Dequeue();

            if (disappear[node] <= time || ans[node] <= time)
            {
                continue;
            }

            ans[node] = time;

            foreach (var (adjNode, length) in adjNodes[node])
            {
                if (disappear[adjNode] <= time + length || ans[adjNode] <= time + length)
                {
                    continue;
                }

                queue.Enqueue((adjNode, time + length));
            }
        }

        for (var i = 0; i < n; i++)
        {
            if (ans[i] == int.MaxValue)
            {
                ans[i] = -1;
            }
        }

        return ans;
    }
}
