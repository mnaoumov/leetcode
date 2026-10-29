namespace LeetCode.Problems._3599_Partition_Array_to_Minimize_XOR;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-456/problems/partition-array-to-minimize-xor/submissions/1679937264/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinXor(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int currentPartitionXor, int maxXor, int partitionsLeft, bool isEmptyPartition), int>((key, recursiveFunc) =>
        {
            var (index, currentPartitionXor, maxXor, partitionsLeft, isEmptyPartition) = key;

            if (index == n && partitionsLeft == 0)
            {
                return maxXor;
            }

            var ans = int.MaxValue;

            if (!isEmptyPartition && (partitionsLeft > 1 || index == n))
            {
                ans = Math.Min(ans,
                    recursiveFunc((index, 0, Math.Max(maxXor, currentPartitionXor), partitionsLeft - 1, true)));
            }

            if (index <= n - partitionsLeft)
            {
                ans = Math.Min(ans,
                    recursiveFunc((index + 1, currentPartitionXor ^ nums[index], maxXor, partitionsLeft, false)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0, k, true));
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
