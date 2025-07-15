namespace LeetCode.Problems._3615_Longest_Palindromic_Path_in_Graph;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-458/problems/longest-palindromic-path-in-graph/submissions/1695911319/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public int MaxLen(int n, int[][] edges, string label)
    {
        var adjNodes = Enumerable.Range(0, n)
            .Select(_ => new List<int>())
            .ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            adjNodes[u].Add(v);
            adjNodes[v].Add(u);
        }

        var ans = 0;

        var queue = new Queue<(int head, int tail, HashSet<int> visitedNodes)>();

        for (var head = 0; head < n; head++)
        {
            for (var tail = head; tail < n; tail++)
            {
                if (label[head] == label[tail])
                {
                    queue.Enqueue((head, tail, new HashSet<int>()));
                }
            }
        }

        while (queue.Count > 0)
        {
            var (head, tail, visitedNodes) = queue.Dequeue();
            var nextVisitedNodes = visitedNodes.ToHashSet();
            nextVisitedNodes.Add(head);
            nextVisitedNodes.Add(tail);
            if (head == tail || adjNodes[head].Contains(tail))
            {
                ans = Math.Max(ans, nextVisitedNodes.Count);
            }

            if (head == tail)
            {
                continue;
            }

            foreach (var nextHead in adjNodes[head].Where(nextNode => !visitedNodes.Contains(nextNode)))
            {
                foreach (var nextTail in adjNodes[tail].Where(nextNode => !visitedNodes.Contains(nextNode)))
                {
                    if (label[nextHead] == label[nextTail])
                    {
                        queue.Enqueue((nextHead, nextTail, nextVisitedNodes));
                    }
                }
            }
        }

        return ans;
    }
}
