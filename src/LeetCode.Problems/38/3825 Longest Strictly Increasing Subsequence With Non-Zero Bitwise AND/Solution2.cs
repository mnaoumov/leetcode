namespace LeetCode.Problems._3825_Longest_Strictly_Increasing_Subsequence_With_Non_Zero_Bitwise_AND;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int LongestSubsequence(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int previousNum, int previousAnd), int>((key, getOrCalculate) =>
        {
            var (index, previousNum, previousAnd) = key;

            if (index == n)
            {
                return 0;
            }

            var ans = getOrCalculate((index + 1, previousNum, previousAnd));

            var num = nums[index];

            if (num > previousNum && (previousAnd & num) != 0)
            {
                ans = Math.Max(ans, 1 + getOrCalculate((index + 1, num, previousAnd & num)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, int.MinValue, int.MaxValue));
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
