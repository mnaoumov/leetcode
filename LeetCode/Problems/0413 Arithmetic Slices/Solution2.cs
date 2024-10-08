namespace LeetCode.Problems._0413_Arithmetic_Slices;

/// <summary>
/// https://leetcode.com/submissions/detail/928783642/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int diff), int>((key, recursiveFunc) =>
        {
            var (index, diff) = key;

            if (index == n)
            {
                return 0;
            }

            return nums[index] == nums[index - 1] + diff
                ? 1 + recursiveFunc((index + 1, diff))
                : 0;
        });

        var result = 0;

        for (var i = 0; i < n - 2; i++)
        {
            result += dp.GetOrCalculate((i + 2, nums[i + 1] - nums[i]));
        }

        return result;
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
