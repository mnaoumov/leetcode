using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3077_Maximum_Strength_of_K_Disjoint_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1199702470/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public long MaximumStrength(int[] nums, int k)
    {
        var n = nums.Length;
        const long impossible = long.MinValue;

        var dp = new DynamicProgramming<(int index, int resultIndex, bool canSkip), long>((key, recursiveFunc) =>
        {
            var (index, resultIndex, canSkip) = key;

            if (resultIndex > k)
            {
                return 0;
            }

            if (n - index < k - resultIndex + 1)
            {
                return impossible;
            }

            var ans = impossible;

            if (canSkip)
            {
                ans = recursiveFunc((index + 1, resultIndex, true));
            }

            var sum = 1L * nums[index] * (k - resultIndex + 1) * (resultIndex % 2 == 1 ? 1 : -1);
            var nextResult = recursiveFunc((index + 1, resultIndex, false));

            if (nextResult != impossible)
            {
                ans = Math.Max(ans, sum + nextResult);
            }

            nextResult = recursiveFunc((index + 1, resultIndex + 1, true));

            if (nextResult != impossible)
            {
                ans = Math.Max(ans, sum + nextResult);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 1, true));
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
