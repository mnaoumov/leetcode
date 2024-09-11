using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2926_Maximum_Balanced_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-370/submissions/detail/1091739661/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MaxBalancedSubsequenceSum(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<int, long>((index, recursiveFunc) =>
        {
            var num = nums[index];

            var ans = 0L + num;

            for (var i = index + 1; i < n; i++)
            {
                if (nums[i] - num >= i - index)
                {
                    ans = Math.Max(ans, num + recursiveFunc(i));
                }
            }

            return ans;
        });

        return Enumerable.Range(0, n).Max(index => dp.GetOrCalculate(index));
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
