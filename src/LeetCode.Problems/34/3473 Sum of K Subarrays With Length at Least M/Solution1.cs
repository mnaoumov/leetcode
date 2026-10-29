namespace LeetCode.Problems._3473_Sum_of_K_Subarrays_With_Length_at_Least_M;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-439/problems/sum-of-k-subarrays-with-length-at-least-m/submissions/1559902691/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxSum(int[] nums, int k, int m)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int startingIndex, int subarraysCount), int>((key, recursiveFunc) =>
        {
            var (startingIndex, subarraysCount) = key;

            if (subarraysCount == 0)
            {
                return 0;
            }

            var ans = int.MinValue;

            if (n - startingIndex > subarraysCount * m)
            {
                ans = recursiveFunc((startingIndex + 1, subarraysCount));
            }

            var sum = 0;

            for (var j = startingIndex; j < n - (subarraysCount - 1) * m; j++)
            {
                sum += nums[j];

                if (j - startingIndex + 1 >= m)
                {
                    ans = Math.Max(ans, sum + recursiveFunc((j + 1, subarraysCount - 1)));
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, k));
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
