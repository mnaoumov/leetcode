namespace LeetCode.Problems._3196_Maximize_Total_Cost_of_Alternating_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-403/submissions/detail/1297257202/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumTotalCost(int[] nums)
    {
        var n = nums.Length;
        var dp = new DynamicProgramming<int, long>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            if (index == n - 1)
            {
                return nums[^1];
            }

            return Math.Max(nums[index] + recursiveFunc(index + 1),
                nums[index] - nums[index + 1] + recursiveFunc(index + 2));
        });

        return dp.GetOrCalculate(0);
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
