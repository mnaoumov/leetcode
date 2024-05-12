using JetBrains.Annotations;

namespace LeetCode._0689_Maximum_Sum_of_3_Non_Overlapping_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/898697080/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        var sums = new int[n - k + 1];

        sums[0] = nums.Take(k).Sum();

        for (var i = 1; i < sums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i - 1 + k] - nums[i - 1];
        }

        var dp = new DynamicProgramming<(int startIndex, int arrayCount), (IEnumerable<int> indices, int sum)>((key, recursiveFunc) =>
        {
            var (startIndex, arrayCount) = key;

            var result = (indices: Enumerable.Empty<int>(), sum: 0);

            if (arrayCount == 0)
            {
                return result;
            }

            var maxSum = int.MinValue;

            for (var i = startIndex; i <= n - arrayCount * k; i++)
            {
                var sum = sums[i];

                if (sum < maxSum)
                {
                    continue;
                }

                maxSum = sum;

                var (indices, restSum) = recursiveFunc((i + k, arrayCount - 1));
                var totalSum = sum + restSum;

                if (result.sum < totalSum)
                {
                    result = (indices: indices.Prepend(i), sum: totalSum);
                }
            }

            return result;
        });

        return dp.GetOrCalculate((0, 3)).indices.ToArray();
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
