namespace LeetCode.Problems._3826_Minimum_Partition_Score;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-175/problems/minimum-partition-score/submissions/1903242442/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MinPartitionScore(int[] nums, int k)
    {
        var n = nums.Length;
        var prefixSums = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var dp = new DynamicProgramming<(int index, int partitionsLeft), long>((key, getOrCalculate) =>
        {
            var (index, partitionsLeft) = key;

            if (index == n)
            {
                return 0;
            }

            var ans = long.MaxValue;

            var minEndIndex = partitionsLeft == 1 ? n - 1 : index;

            for (var endIndex = minEndIndex; endIndex <= n - partitionsLeft; endIndex++)
            {
                var sumArr = prefixSums[endIndex + 1] - prefixSums[index];
                var value = 1L * sumArr * (sumArr + 1) / 2;

                ans = Math.Min(ans, value + getOrCalculate((endIndex + 1, partitionsLeft - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, k));
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
