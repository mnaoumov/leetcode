namespace LeetCode.Problems._3615_Longest_Palindromic_Path_in_Graph;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-458/problems/longest-palindromic-path-in-graph/submissions/1695891905/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
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

        var dp = new DynamicProgramming<(int node, string visitedNodesStr, string prefix), int>((key, recursiveFunc) =>
        {
            var (node, visitedNodesStr, prefix) = key;

            var visitedNodes =
                new SortedSet<int>(visitedNodesStr.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var nextPrefix = prefix + label[node];

            var ans = 0;

            if (nextPrefix == new string(nextPrefix.Reverse().ToArray()))
            {
                ans = nextPrefix.Length;
            }

            visitedNodes.Add(node);
            var nextVisitedNodesStr = string.Join(',', visitedNodes);

            ans = adjNodes[node]
                .Where(adjNode => !visitedNodes.Contains(adjNode))
                .Select(adjNode => recursiveFunc((adjNode, nextVisitedNodesStr, nextPrefix)))
                .Prepend(ans)
                .Max();

            return ans;
        });

        return Enumerable.Range(0, n).Max(node => dp.GetOrCalculate((node, "", "")));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
