namespace LeetCode.Problems._1746_Maximum_Subarray_Sum_After_One_Operation;

/// <summary>
/// https://leetcode.com/submissions/detail/938735622/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSumAfterOperation(int[] nums)
    {
        var dp = new DynamicProgramming<(int index, bool canSquare), int>((key, recursiveFunc) =>
        {
            var (index, canSquare) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            var result = Math.Max(0, nums[index] + recursiveFunc((index + 1, canSquare)));

            if (canSquare)
            {
                result = Math.Max(result, nums[index] * nums[index] + recursiveFunc((index + 1, false)));
            }

            return result;
        });

        return Enumerable.Range(0, nums.Length).Max(index => dp.GetOrCalculate((index, true)));
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
