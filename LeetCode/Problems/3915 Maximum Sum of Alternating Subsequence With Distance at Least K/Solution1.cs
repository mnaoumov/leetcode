namespace LeetCode.Problems._3915_Maximum_Sum_of_Alternating_Subsequence_With_Distance_at_Least_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-499/problems/maximum-sum-of-alternating-subsequence-with-distance-at-least-k/submissions/1988262805/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaxAlternatingSum(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int previousValue, int diffSign), int>((key, getOrCalculate) =>
        {
            var (index, previousValue, diffSign) = key;

            if (index >= n)
            {
                return 0;
            }

            var ans2 = getOrCalculate((index + 1, previousValue, diffSign));

            var num = nums[index];

            if (Math.Sign(num.CompareTo(previousValue)) == diffSign)
            {
                ans2 = Math.Max(ans2, num + getOrCalculate((index + k, num, -diffSign)));
            }

            return ans2;
        });

        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            ans = Math.Max(ans, nums[i] + dp.GetOrCalculate((i + k, nums[i], 1)));
            ans = Math.Max(ans, nums[i] + dp.GetOrCalculate((i + k, nums[i], -1)));
        }

        return ans;
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
