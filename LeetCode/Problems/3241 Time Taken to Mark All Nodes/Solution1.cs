using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3241_Time_Taken_to_Mark_All_Nodes;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-136/submissions/detail/1343223654/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] TimeTaken(int[][] edges)
    {
        var n = edges.Length + 1;
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[u].Add(v);
            adjNodes[v].Add(u);
        }

        var queue = new PriorityQueue<(int node, int time, int initialNode), int>();

        var visitedNodes = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            queue.Enqueue((i, 0, i), 0);
        }

        var ans = new int[n];

        while (queue.Count > 0)
        {
            var (node, time, initialNode) = queue.Dequeue();

            visitedNodes[initialNode].Add(node);

            if (visitedNodes[initialNode].Count == n)
            {
                ans[initialNode] = time;
                continue;
            }

            foreach (var adjNode in adjNodes[node].Where(adjNode => !visitedNodes[initialNode].Contains(adjNode)))
            {
                var nextTime = time + (adjNode % 2 == 1 ? 1 : 2);
                queue.Enqueue((adjNode, nextTime, initialNode), nextTime);
            }
        }

        return ans;
    }
}
