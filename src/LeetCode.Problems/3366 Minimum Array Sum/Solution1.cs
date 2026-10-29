namespace LeetCode.Problems._3366_Minimum_Array_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-425/submissions/detail/1461266628/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinArraySum(int[] nums, int k, int op1, int op2)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int op1Left, int op2Left), int>((key, recursiveFunc) =>
        {
            var (index, op1Left, op2Left) = key;

            if (index == n)
            {
                return 0;
            }

            var value = nums[index];

            var ans = value + recursiveFunc((index + 1, op1Left, op2Left));

            if (op1Left > 0)
            {
                var nextValue = (value + 1) / 2;
                ans = Math.Min(ans, nextValue + recursiveFunc((index + 1, op1Left - 1, op2Left)));

                if (op2Left > 0 && nextValue >= k)
                {
                    ans = Math.Min(ans, nextValue - k + recursiveFunc((index + 1, op1Left - 1, op2Left - 1)));
                }
            }

            // ReSharper disable once InvertIf
            if (op2Left > 0 && value >= k)
            {
                var nextValue = value - k;
                ans = Math.Min(ans, nextValue + recursiveFunc((index + 1, op1Left, op2Left - 1)));

                if (op1Left > 0)
                {
                    ans = Math.Min(ans, (nextValue + 1) / 2 + recursiveFunc((index + 1, op1Left - 1, op2Left - 1)));
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, op1, op2));
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
