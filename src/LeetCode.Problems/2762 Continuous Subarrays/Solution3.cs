namespace LeetCode.Problems._2762_Continuous_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1478356023/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long ContinuousSubarrays(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int min, int max, bool hasStarted), long>((key, recursiveFunc) =>
        {
            var (index, min, max, hasStarted) = key;

            if (index == n)
            {
                return 0;
            }

            var num = nums[index];

            var ans = 0L;

            if (!hasStarted)
            {
                ans += recursiveFunc((index + 1, min, max, false));
            }

            if (min <= num && num <= max)
            {
                ans += 1 + recursiveFunc((index + 1, Math.Max(min, num - 2), Math.Min(max, num + 2), true));
            }

            return ans;

        });

        return dp.GetOrCalculate((0, int.MinValue, int.MaxValue, false));
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
