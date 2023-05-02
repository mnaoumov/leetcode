using JetBrains.Annotations;

namespace LeetCode._0502_IPO;

/// <summary>
/// https://leetcode.com/submissions/detail/895951147/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution4 : ISolution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        var dp = new DynamicProgramming<(int index, int projectCountAvailable, int capitalAvailable), int>((key, recursiveFunc) =>
        {
            var (index, projectCountAvailable, capitalAvailable) = key;

            if (index == profits.Length || projectCountAvailable == 0)
            {
                return capitalAvailable;
            }

            var result = recursiveFunc((index + 1, projectCountAvailable, capitalAvailable));

            if (capital[index] <= capitalAvailable)
            {
                result = Math.Max(result,
                    recursiveFunc((index + 1, projectCountAvailable - 1, capitalAvailable + profits[index])));
            }

            return result;
        });

        return dp.GetOrCalculate((0, k, w));
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
