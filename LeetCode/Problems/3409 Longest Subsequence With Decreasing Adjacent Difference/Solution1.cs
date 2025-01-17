namespace LeetCode.Problems._3409_Longest_Subsequence_With_Decreasing_Adjacent_Difference;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-147/submissions/detail/1497478098/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestSubsequence(int[] nums)
    {
        const int noValue = 0;
        const int noDiff = int.MaxValue;

        var dp = new DynamicProgramming<(int index, int previousValue, int previousDiff), int>((key, recursiveFunc) =>
        {
            var (index, previousValue, previousDiff) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            var diff = Math.Abs(nums[index] - previousValue);

            var ans = recursiveFunc((index + 1, previousValue, previousDiff));

            if (diff <= previousDiff)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, nums[index], diff)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noValue, noDiff));
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
