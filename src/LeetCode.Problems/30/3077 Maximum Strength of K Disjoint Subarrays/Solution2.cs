namespace LeetCode.Problems._3077_Maximum_Strength_of_K_Disjoint_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-388/submissions/detail/1199191210/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MaximumStrength(int[] nums, int k)
    {
        var n = nums.Length;
        const long impossible = long.MinValue;

        var dp = new DynamicProgramming<(int index, int resultIndex), long>((key, recursiveFunc) =>
        {
            var (index, resultIndex) = key;

            if (resultIndex > k)
            {
                return 0;
            }

            if (n - index < k - resultIndex + 1)
            {
                return impossible;
            }

            var ans = recursiveFunc((index + 1, resultIndex));

            var sum = 0L;

            for (var j = index; j <= n - k + resultIndex - 1; j++)
            {
                sum += nums[j];

                var nextResult = recursiveFunc((j + 1, resultIndex + 1));

                if (nextResult != impossible)
                {
                    ans = Math.Max(ans, sum * (k - resultIndex + 1) * (resultIndex % 2 == 1 ? 1 : -1) + nextResult);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 1));
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
