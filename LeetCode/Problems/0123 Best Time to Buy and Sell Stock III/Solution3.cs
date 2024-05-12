using JetBrains.Annotations;

namespace LeetCode._0123_Best_Time_to_Buy_and_Sell_Stock_III;

/// <summary>
/// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/submissions/836920843/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaxProfit(int[] prices)
    {
        var cache = new Dictionary<(int day, bool hasStock, int amountOfTransactions), int>();

        var stack = new Stack<(int day, bool hasStock, int amountOfTransactions)>();

        stack.Push((0, false, 0));

        while (stack.Count > 0)
        {
            var key = stack.Pop();

            if (cache.ContainsKey(key))
            {
                continue;
            }

            var (day, hasStock, amountOfTransactions) = key;

            if (day == prices.Length)
            {
                cache[key] = 0;
                continue;
            }

            if (amountOfTransactions == 2)
            {
                cache[key] = 0;
                continue;
            }

            var price = prices[day];

            var skipTransactionKey = (day + 1, hasStock, amountOfTransactions);
            var sellKey = (day + 1, false, amountOfTransactions + 1);
            var buyKey = (day + 1, true, amountOfTransactions);
            var performTransactionKey = hasStock ? sellKey : buyKey;

            if (cache.TryGetValue(skipTransactionKey, out var skipTransactionResult) &&
                cache.TryGetValue(performTransactionKey, out var performTransactionResult))
            {
                cache[key] = Math.Max(skipTransactionResult,
                    (hasStock ? price : -price) + performTransactionResult);
            }
            else
            {
                stack.Push(key);
                stack.Push(skipTransactionKey);
                stack.Push(performTransactionKey);
            }
        }

        return cache[(0, false, 0)];
    }
}
