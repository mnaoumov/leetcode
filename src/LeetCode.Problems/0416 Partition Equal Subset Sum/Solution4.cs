namespace LeetCode.Problems._0416_Partition_Equal_Subset_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/888158207/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool CanPartition(int[] nums)
    {
        var sum = nums.Sum();

        if (sum % 2 == 1)
        {
            return false;
        }

        var dp = new DynamicProgramming<(int index, int targetSum), bool>((key, recursiveFunc) =>
        {
            var (index, targetSum) = key;

            if (index == nums.Length)
            {
                return false;
            }

            if (nums[index] == targetSum)
            {
                return true;
            }

            return recursiveFunc((index + 1, targetSum)) ||
                   nums[index] < targetSum && recursiveFunc((index + 1, targetSum - nums[index]));
        });

        return dp.GetOrCalculate((0, sum / 2));
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
