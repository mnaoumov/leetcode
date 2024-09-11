using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0276_Paint_Fence;

/// <summary>
/// https://leetcode.com/submissions/detail/927259729/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int NumWays(int n, int k)
    {
        var dp = new DynamicProgramming<(int index, int color1, int color2), int>((key, recursiveFunc) =>
        {
            var (index, color1, color2) = key;

            if (index == n)
            {
                return 1;
            }

            var result = 0;

            for (var i = 0; i < k; i++)
            {
                if (color1 == color2 && color2 == i)
                {
                    continue;
                }

                result += recursiveFunc((index + 1, i, color1));
            }

            return result;
        });

        return dp.GetOrCalculate((0, -1, -1));
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
