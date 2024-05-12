using JetBrains.Annotations;

namespace LeetCode.Problems._0265_Paint_House_II;

/// <summary>
/// https://leetcode.com/submissions/detail/927268538/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCostII(int[][] costs)
    {
        var n = costs.Length;
        var k = costs[0].Length;

        var dp = new DynamicProgramming<(int index, int previousColor), int>((key, recursiveFunc) =>
        {
            var (index, previousColor) = key;

            if (index == n)
            {
                return 0;
            }

            var result = int.MaxValue;

            for (var i = 0; i < k; i++)
            {
                if (i == previousColor)
                {
                    continue;
                }

                result = Math.Min(result, costs[index][i] + recursiveFunc((index + 1, i)));
            }

            return result;
        });

        return dp.GetOrCalculate((0, -1));
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
