using JetBrains.Annotations;

namespace LeetCode._0698_Partition_to_K_Equal_Sum_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/974304508/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        var sum = nums.Sum();

        if (sum % k != 0)
        {
            return false;
        }

        var partSum = sum / k;

        Array.Sort(nums);
        
        var dp = new DynamicProgramming<(int index, string partSumsStr), bool>((key, recursiveFunc) =>
        {
            var (index, partSumsStr) = key;
            var partSums = partSumsStr.Split(',').Select(int.Parse).ToArray();

            if (index == nums.Length)
            {
                return partSums[0] == 0;
            }

            var num = nums[index];

            for (var i = 0; i < k; i++)
            {
                if (partSums[i] < num)
                {
                    return false;
                }

                if (i > 0 && partSums[i - 1] == partSums[i])
                {
                    continue;
                }

                partSums[i] -= num;

                if (recursiveFunc((index + 1, string.Join(',', partSums.OrderByDescending(x => x)))))
                {
                    return true;
                }

                partSums[i] += num;
            }

            return false;
        });

        return dp.GetOrCalculate((0, string.Join(',', Enumerable.Repeat(partSum, k))));
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
