namespace LeetCode.Problems._0312_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/881585051/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MaxCoins(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int startIndex, int endIndex), int>((key, recursiveFunc) =>
        {
            var (startIndex, endIndex) = key;

            if (startIndex > endIndex)
            {
                return 0;
            }

            var result = int.MinValue;

            for (var i = startIndex; i <= endIndex; i++)
            {
                var currentResult =
                    recursiveFunc((startIndex, i - 1))
                    + SafeGet(startIndex - 1) * SafeGet(i) * SafeGet(endIndex + 1)
                    + recursiveFunc((i + 1, endIndex));

                result = Math.Max(result, currentResult);
            }

            return result;
        });

        return dp.GetOrCalculate((0, n - 1));

        int SafeGet(int index) => 0 <= index && index < n ? nums[index] : 1;
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
