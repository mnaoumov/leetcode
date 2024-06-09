using JetBrains.Annotations;

namespace LeetCode.Problems._3176_Find_the_Maximum_Length_of_a_Good_Subsequence_I;

/// <summary>
/// https://leetcode.com/submissions/detail/1281751107/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaximumLength(int[] nums, int k)
    {
        const int noIndex = -1;

        var dp = new DynamicProgramming<(int index, int previousIndex, int allowedSequentialNonEqualCount), int>((key, recursiveFunc) =>
        {
            var (index, previousIndex, allowedSequentialNonEqualCount) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            var ans = recursiveFunc((index + 1, previousIndex, allowedSequentialNonEqualCount));

            if (previousIndex == noIndex || nums[index] == nums[previousIndex])
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, index, allowedSequentialNonEqualCount)));
            }
            else if (allowedSequentialNonEqualCount > 0)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, index, allowedSequentialNonEqualCount - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noIndex, k));
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
