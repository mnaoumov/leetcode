namespace LeetCode.Problems._3620_Network_Recovery_Pathways;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution3 : ISolution
{
    public int FindMaxPathScore(int[][] edges, bool[] online, long k)
    {
        var n = online.Length;
        var edgesObjs = edges
            .Select(e => new Edge(e[0], e[1], e[2]))
            .ToArray();
        var edgesGroupedByFromNode = edgesObjs.Where(e => online[e.To]).GroupBy(e => e.From).ToDictionary(g => g.Key, g => g.ToArray());

        var dp = new DynamicProgramming<(int node, long totalCostLeft, int minEdgeCost), int>((key, recursiveFunc) =>
        {
            var (node, totalCostLeft, minEdgeCost) = key;

            if (node == n - 1)
            {
                return minEdgeCost;
            }

            var ans = -1;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var edge in edgesGroupedByFromNode.GetValueOrDefault(node, Array.Empty<Edge>()))
            {
                var nextTotalCostLeft = totalCostLeft - edge.Cost;
                if (nextTotalCostLeft < 0)
                {
                    continue;
                }

                ans = Math.Max(ans, recursiveFunc((edge.To, nextTotalCostLeft, Math.Min(minEdgeCost, edge.Cost))));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, k, int.MaxValue));
    }

    private record Edge(int From, int To, int Cost);

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
