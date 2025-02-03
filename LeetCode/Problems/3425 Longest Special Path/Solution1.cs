namespace LeetCode.Problems._3425_Longest_Special_Path;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-148/problems/longest-special-path/submissions/1512664433/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] LongestSpecialPath(int[][] edges, int[] nums)
    {
        var n = edges.Length + 1;
        var edgeObjs = Enumerable.Range(0, n).Select(_ => new List<Edge>()).ToArray();

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var length = edge[2];
            var edgeObj = new Edge(u, v, length);
            edgeObjs[u].Add(edgeObj);
            edgeObjs[v].Add(edgeObj);
        }

        var parents = new int[n];

        InitParents(0);

        var dp = new DynamicProgramming<(int node, string valuesToSkipStr), (int length, int nodesCount)>((key, recursiveFunc) =>
        {
            var (node, valuesToSkipStr) = key;
            var valuesToSkip = valuesToSkipStr.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToHashSet();
            var value = nums[node];
            if (!valuesToSkip.Add(value))
            {
                return (length: 0, nodesCount: 0);
            }

            var nextValuesToSkipStr = string.Join(",", valuesToSkip.OrderBy(x => x));

            var ans = (length: 0, nodesCount: 1);

            foreach (var edge in edgeObjs[node])
            {
                var adj = edge.Adj(node);

                if (adj == parents[node])
                {
                    continue;
                }

                var next = recursiveFunc((adj, nextValuesToSkipStr));

                if (next == (0, 0))
                {
                    continue;
                }

                var nextLength = next.length + edge.Length;

                if (nextLength > ans.length)
                {
                    ans = (nextLength, next.nodesCount + 1);
                }
                else if (nextLength == ans.length)
                {
                    ans = (ans.length, Math.Min(ans.nodesCount, next.nodesCount + 1));
                }
            }

            return ans;
        });

        var specialPaths = Enumerable.Range(0, n).Select(node => dp.GetOrCalculate((node, ""))).ToArray();
        var maxLength = specialPaths.Select(x => x.length).Max();
        var minNodesCount = specialPaths.Where(x => x.length == maxLength).Select(x => x.nodesCount).Min();
        return new[] { maxLength, minNodesCount };

        void InitParents(int node)
        {
            foreach (var adj in edgeObjs[node].Select(edge => edge.Adj(node)).Where(adj => adj != parents[node]))
            {
                parents[adj] = node;
                InitParents(adj);
            }
        }
    }

    private record Edge(int U, int V, int Length)
    {
        public int Adj(int node)
        {
            if (node == U)
            {
                return V;
            }

            if (node == V)
            {
                return U;
            }

            throw new InvalidOperationException();
        }
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
