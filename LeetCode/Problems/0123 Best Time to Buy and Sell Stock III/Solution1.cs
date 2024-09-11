using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0123_Best_Time_to_Buy_and_Sell_Stock_III;

/// <summary>
/// https://leetcode.com/submissions/detail/836268641/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        var dp = new DynamicProgramming<(int day, bool hasStock, int amountOfTransactions), int>((key, calculateFunc) =>
        {
            var (day, hasStock, amountOfTransactions) = key;

            if (day == prices.Length)
            {
                return 0;
            }

            if (amountOfTransactions == 2)
            {
                return 0;
            }

            var price = prices[day];

            return Math.Max(calculateFunc((day + 1, hasStock, amountOfTransactions)),
                hasStock
                    ? price + calculateFunc((day + 1, false, amountOfTransactions + 1))
                    : -price + calculateFunc((day + 1, true, amountOfTransactions)));
        });

        return dp.GetOrCalculate(((0, false, 0)));
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
