namespace LeetCode.Problems._1770_Maximum_Score_from_Performing_Multiplication_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/927249917/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        var n = nums.Length;
        var m = multipliers.Length;

        var dp = new DynamicProgramming<(int start, int end), int>((key, recursiveFunc) =>
        {
            var (start, end) = key;

            var multiplierIndex = n - 1 - end + start;

            if (multiplierIndex >= m)
            {
                return 0;
            }

            var multiplier = multipliers[multiplierIndex];

            return Math.Max(
                nums[start] * multiplier + recursiveFunc((start + 1, end)),
                nums[end] * multiplier + recursiveFunc((start, end - 1))
            );
        });

        return dp.GetOrCalculate((0, n - 1));
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
