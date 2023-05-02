using JetBrains.Annotations;

namespace LeetCode._0474_Ones_and_Zeroes;

/// <summary>
/// https://leetcode.com/submissions/detail/921089091/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        var counts = strs.Select(str =>
        {
            var zeros = str.Count(digit => digit == '0');
            return (zeros, ones: str.Length - zeros);
        }).ToArray();

        var dp = new DynamicProgramming<(int index, int zerosLeft, int onesLeft), int>((key, recursiveFunc) =>
        {
            var (index, zerosLeft, onesLeft) = key;

            if (index == strs.Length || m == 0 && n == 0)
            {
                return 0;
            }

            var result = recursiveFunc((index + 1, zerosLeft, onesLeft));
            var (zeros, ones) = counts[index];

            if (zeros <= zerosLeft && ones <= onesLeft)
            {
                result = Math.Max(result,
                    1 + recursiveFunc((index + 1, zerosLeft - zeros, onesLeft - ones)));
            }

            return result;
        });

        return dp.GetOrCalculate((0, m, n));
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
