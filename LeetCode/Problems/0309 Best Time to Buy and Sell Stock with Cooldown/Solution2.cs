namespace LeetCode.Problems._0309_Best_Time_to_Buy_and_Sell_Stock_with_Cooldown;

/// <summary>
/// https://leetcode.com/submissions/detail/834070250/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        var dp = new DynamicProgramming<(int day, bool hasStock), int>((key, calculateFunc) =>
        {
            var (day, hasStock) = key;
            if (day >= prices.Length)
            {
                return 0;
            }

            return Math.Max(calculateFunc((day + 1, hasStock)),
                hasStock
                    ? prices[day] + calculateFunc((day + 2, false))
                    : -prices[day] + calculateFunc((day + 1, true)));
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
