namespace LeetCode.Problems._0487_Max_Consecutive_Ones_II;

/// <summary>
/// https://leetcode.com/submissions/detail/938724981/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var dp = new DynamicProgramming<(int index, bool canFlip), int>((key, recursiveFunc) =>
        {
            var (index, canFlip) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            if (nums[index] == 1)
            {
                return 1 + recursiveFunc((index + 1, canFlip));
            }

            return canFlip ? 1 + recursiveFunc((index + 1, false)) : 0;
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
