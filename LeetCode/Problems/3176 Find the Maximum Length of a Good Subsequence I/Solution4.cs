using JetBrains.Annotations;

namespace LeetCode.Problems._3176_Find_the_Maximum_Length_of_a_Good_Subsequence_I;

/// <summary>
/// NotImplemented
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution4 : ISolution
{
    public int MaximumLength(int[] nums, int k)
    {
        var dp = new DynamicProgramming<(int index, int previousValue, int allowedSequentialNonEqualCount), int>((key, recursiveFunc) =>
        {
            var (index, previousValue, allowedSequentialNonEqualCount) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            var ans = 0;

            var num = nums[index];

            if (num == previousValue)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, num, allowedSequentialNonEqualCount)));
            }
            else
            {
                ans = Math.Max(ans, recursiveFunc((index + 1, previousValue, allowedSequentialNonEqualCount)));

                if (allowedSequentialNonEqualCount > 0)
                {
                    ans = Math.Max(ans, 1 + recursiveFunc((index + 1, num, allowedSequentialNonEqualCount - 1)));
                }
            }

            return ans;
        });

        return Enumerable.Range(0, nums.Length).Select(i => dp.GetOrCalculate((i, nums[i], k))).Max();
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
