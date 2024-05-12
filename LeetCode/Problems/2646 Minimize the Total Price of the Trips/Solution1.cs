using JetBrains.Annotations;

namespace LeetCode.Problems._2646_Minimize_the_Total_Price_of_the_Trips;

/// <summary>
/// https://leetcode.com/submissions/detail/936074533/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        var frequencies = new int[n];

        foreach (var trip in trips)
        {
            var start = trip[0];
            var end = trip[1];

            var seen = new bool[n];

            Dfs(start);
            continue;

            bool Dfs(int node)
            {
                seen[node] = true;

                if (node == end)
                {
                    frequencies[node]++;
                    return true;
                }

                if (!adjNodes[node].Where(adjNode => !seen[adjNode]).Any(Dfs))
                {
                    return false;
                }

                frequencies[node]++;
                return true;
            }
        }

        var parents = new int[n];
        Dfs2(0, -1);

        var dp = new DynamicProgramming<(int node, bool isHalved), int>((key, recursiveFunc) =>
        {
            var (node, isHalved) = key;

            var result = price[node] / (isHalved ? 2 : 1) * frequencies[node];

            foreach (var adjNode in adjNodes[node].Except(new[] { parents[node] }))
            {
                var subResult = recursiveFunc((adjNode, false));

                if (!isHalved)
                {
                    subResult = Math.Min(subResult, recursiveFunc((adjNode, true)));
                }

                result += subResult;
            }

            return result;
        });

        return Math.Min(dp.GetOrCalculate((0, false)), dp.GetOrCalculate((0, true)));

        void Dfs2(int node, int parent)
        {
            parents[node] = parent;

            foreach (var adjNode in adjNodes[node].Except(new[] { parent }))
            {
                Dfs2(adjNode, node);
            }
        }
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
