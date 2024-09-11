using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3176_Find_the_Maximum_Length_of_a_Good_Subsequence_I;

/// <summary>
/// https://leetcode.com/submissions/detail/1281766771/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaximumLength(int[] nums, int k)
    {
        const int noValue = int.MinValue;

        var dp = new DynamicProgramming<(int index, int previousValue, int allowedSequentialNonEqualCount), int>((key, recursiveFunc) =>
        {
            var (index, previousValue, allowedSequentialNonEqualCount) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            var ans = recursiveFunc((index + 1, previousValue, allowedSequentialNonEqualCount));

            var num = nums[index];

            if (previousValue == noValue || num == previousValue)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, num, allowedSequentialNonEqualCount)));
            }
            else if (allowedSequentialNonEqualCount > 0)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, num, allowedSequentialNonEqualCount - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noValue, k));
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
