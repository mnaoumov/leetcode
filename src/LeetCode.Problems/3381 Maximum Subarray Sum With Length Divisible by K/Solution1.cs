namespace LeetCode.Problems._3381_Maximum_Subarray_Sum_With_Length_Divisible_by_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-427/submissions/detail/1473140508/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int startingIndex, bool allowEmpty), long>((key, recursiveFunc) =>
        {
            var (startingIndex, allowEmpty) = key;

            if (startingIndex > n - k)
            {
                return 0;
            }

            var sum = 0L;
            for (var i = startingIndex; i < startingIndex + k; i++)
            {
                sum += nums[i];
            }

            var ans = sum + recursiveFunc((startingIndex + k, true));

            if (ans < 0 && allowEmpty)
            {
                ans = 0;
            }

            return ans;
        });

        return Enumerable.Range(0, n - k).Select(i => dp.GetOrCalculate((i, false))).Max();
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
