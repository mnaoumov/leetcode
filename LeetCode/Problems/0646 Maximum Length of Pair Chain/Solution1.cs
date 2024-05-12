using JetBrains.Annotations;

namespace LeetCode._0646_Maximum_Length_of_Pair_Chain;

/// <summary>
/// https://leetcode.com/submissions/detail/940880167/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLongestChain(int[][] pairs)
    {
        pairs = pairs.OrderBy(p => p[0]).ToArray();
        var n = pairs.Length;

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            var result = 1;

            for (var i = index + 1; i < n; i++)
            {
                if (pairs[index][1] < pairs[i][0])
                {
                    result = Math.Max(result, 1 + recursiveFunc(i));
                }
            }

            return result;
        });

        return Enumerable.Range(0, n).Max(i => dp.GetOrCalculate(i));
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
