using JetBrains.Annotations;

namespace LeetCode.Problems._0276_Paint_Fence;

/// <summary>
/// https://leetcode.com/submissions/detail/927263513/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumWays(int n, int k)
    {
        var dp = new DynamicProgramming<(int index, int repeatingColorCount), int>((key, recursiveFunc) =>
        {
            var (index, repeatingColorCount) = key;

            if (index == n)
            {
                return 1;
            }

            var result = (k - 1) * recursiveFunc((index + 1, 1));

            if (repeatingColorCount < 2)
            {
                result += recursiveFunc((index + 1, repeatingColorCount + 1));
            }

            return result;
        });

        return dp.GetOrCalculate((0, 0));
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
