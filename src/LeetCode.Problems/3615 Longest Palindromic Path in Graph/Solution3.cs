namespace LeetCode.Problems._3615_Longest_Palindromic_Path_in_Graph;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-458/problems/longest-palindromic-path-in-graph/submissions/1695895884/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
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

        var queue = new Queue<(int node, HashSet<int> visitedNodes, string prefix, string inversePrefix)>();

        for (var i = 0; i < n; i++)
        {
            queue.Enqueue((i, new HashSet<int>(), "", ""));
        }

        while (queue.Count > 0)
        {
            var (node, visitedNodes, prefix, inversePrefix) = queue.Dequeue();
            var nextPrefix = prefix + label[node];
            var nextInversePrefix = label[node] + inversePrefix;
            if (nextPrefix.Length > ans && nextPrefix == nextInversePrefix)
            {
                ans = nextPrefix.Length;
            }
            var nextVisitedNodes = new HashSet<int>(visitedNodes) { node };
            foreach (var nextNode in adjNodes[node].Where(nextNode => !nextVisitedNodes.Contains(nextNode)))
            {
                queue.Enqueue((nextNode, nextVisitedNodes, nextPrefix, nextInversePrefix));
            }
        }

        return ans;
    }
}
