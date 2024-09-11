namespace LeetCode.Problems._0714_Best_Time_to_Buy_and_Sell_Stock_with_Transaction_Fee;

/// <summary>
/// https://leetcode.com/submissions/detail/919885781/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProfit(int[] prices, int fee)
    {
        var dp = new DynamicProgramming<(int day, bool hasStock), int>((key, recursiveFunc) =>
        {
            var (day, hasStock) = key;

            if (day == prices.Length)
            {
                return 0;
            }

            return Math.Max(
                recursiveFunc((day + 1, hasStock)),
                hasStock
                    ? prices[day] - fee + recursiveFunc((day + 1, false))
                    : -prices[day] + recursiveFunc((day + 1, true))
            );
        });

        return dp.GetOrCalculate((0, false));
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
