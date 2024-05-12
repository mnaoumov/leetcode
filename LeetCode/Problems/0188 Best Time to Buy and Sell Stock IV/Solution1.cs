using JetBrains.Annotations;

namespace LeetCode.Problems._0188_Best_Time_to_Buy_and_Sell_Stock_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/919854885/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProfit(int k, int[] prices)
    {
        var dp = new DynamicProgramming<(int day, int transactionsLeft, bool hasStock), int>((key, recursiveFunc) =>
        {
            var (day, transactionsLeft, hasStock) = key;

            if (day == prices.Length || transactionsLeft == 0)
            {
                return 0;
            }

            return Math.Max(
                recursiveFunc((day + 1, transactionsLeft, hasStock)),
                hasStock
                    ? prices[day] + recursiveFunc((day + 1, transactionsLeft - 1, false))
                    : -prices[day] + recursiveFunc((day + 1, transactionsLeft, true)));
        });

        return dp.GetOrCalculate((0, k, false));
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
