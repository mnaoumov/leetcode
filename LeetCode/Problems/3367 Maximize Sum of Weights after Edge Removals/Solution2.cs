namespace LeetCode.Problems._3367_Maximize_Sum_of_Weights_after_Edge_Removals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-425/submissions/detail/1461298031/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MaximizeSumOfWeights(int[][] edges, int k)
    {
        var n = edges.Length + 1;
        var edgeCounts = new int[n];

        var sum = 0L;

        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            var w = edge[2];
            edgeCounts[u]++;
            edgeCounts[v]++;
            sum += w;
        }

        const int badResult = int.MaxValue;

        var dp = new DynamicProgramming<(int index, string edgeCountsStr), int>((key, recursiveFunc) =>
        {
            var (index, edgeCountsStr) = key;
            var edgeCounts2 = edgeCountsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            if (edgeCounts2.All(count => count <= k))
            {
                return 0;
            }

            if (index >= edges.Length)
            {
                return badResult;
            }

            var ans = recursiveFunc((index + 1, edgeCountsStr));

            var edge = edges[index];
            var u = edge[0];
            var v = edge[1];
            var w  = edge[2];

            if (edgeCounts[u] <= k && edgeCounts[v] <= k)
            {
                return ans;
            }

            edgeCounts2[u]--;
            edgeCounts2[v]--;
            var nextResult = recursiveFunc((index + 1, string.Join(' ', edgeCounts2)));

            if (nextResult != badResult)
            {
                ans = Math.Min(ans, w + nextResult);
            }

            return ans;
        });

        return sum - dp.GetOrCalculate((0, string.Join(' ', edgeCounts)));
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
