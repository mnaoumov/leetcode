using JetBrains.Annotations;

namespace LeetCode.Problems._1567_Maximum_Length_of_Subarray_With_Positive_Product;

/// <summary>
/// https://leetcode.com/submissions/detail/926834806/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetMaxLen(int[] nums)
    {
        var dp = new DynamicProgramming<(int index, int sign), int>((key, recursiveFunc) =>
        {
            var (index, sign) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            if (nums[index] == 0)
            {
                return 0;
            }

            var currentSign = Math.Sign(nums[index]);
            var subResult = recursiveFunc((index + 1, sign * currentSign));
            return sign * currentSign == -1 && subResult == 0 ? 0 : 1 + subResult;
        });

        return Enumerable.Range(0, nums.Length).Max(index => dp.GetOrCalculate((index, 1)));
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
