using JetBrains.Annotations;

namespace LeetCode.Problems._2926_Maximum_Balanced_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-370/submissions/detail/1091732218/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaxBalancedSubsequenceSum(int[] nums)
    {
        var n = nums.Length;
        const int noIndex = -1;

        var dp = new DynamicProgramming<(int index, int lastIndex), long>((key, recursiveFunc) =>
        {
            var (index, lastIndex) = key;

            if (index == n)
            {
                return 0;
            }

            var num = nums[index];

            if (index == n - 1 && lastIndex == noIndex)
            {
                return num;
            }

            var ans = recursiveFunc((index + 1, lastIndex));

            if (lastIndex == noIndex || num - nums[lastIndex] >= index - lastIndex)
            {
                ans = Math.Max(ans, num + recursiveFunc((index + 1, index)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noIndex));
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
