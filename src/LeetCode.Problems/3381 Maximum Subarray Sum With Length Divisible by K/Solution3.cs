namespace LeetCode.Problems._3381_Maximum_Subarray_Sum_With_Length_Divisible_by_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-427/submissions/detail/1473146224/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        var n = nums.Length;
        var kSums = new long[n - k + 1];

        for (var i = 0; i < k; i++)
        {
            kSums[0] += nums[i];
        }

        for (var i = 1; i < n - k + 1; i++)
        {
            kSums[i] = kSums[i - 1] - nums[i - 1] + nums[i + k - 1];
        }

        var dp = new DynamicProgramming<(int startingIndex, bool allowEmpty), long>((key, recursiveFunc) =>
        {
            var (startingIndex, allowEmpty) = key;

            if (startingIndex > n - k)
            {
                return 0;
            }

            var ans = kSums[startingIndex] + recursiveFunc((startingIndex + k, true));

            if (ans < 0 && allowEmpty)
            {
                ans = 0;
            }

            return ans;
        });

        return Enumerable.Range(0, n - k + 1).Select(i => dp.GetOrCalculate((i, false))).Max();
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
