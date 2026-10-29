namespace LeetCode.Problems._3573_Best_Time_to_Buy_and_Sell_Stock_V;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-158/problems/best-time-to-buy-and-sell-stock-v/submissions/1656717431/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumProfit(int[] prices, int k)
    {
        const long impossible = long.MinValue;

        var dp = new DynamicProgramming<(int day, Transaction transaction, int transactionsLeft), long>((key, recursiveFunc) =>
        {
            var (day, transaction, transactionsLeft) = key;

            if (day == prices.Length || transactionsLeft == 0)
            {
                return transaction == Transaction.None ? 0 : impossible;
            }

            var ans = recursiveFunc((day + 1, transaction, transactionsLeft));

            switch (transaction)
            {
                case Transaction.None:
                    UpdateAns(Transaction.Normal, transactionsLeft, true);
                    UpdateAns(Transaction.ShortSelling, transactionsLeft, false);
                    break;
                case Transaction.Normal:
                    UpdateAns(Transaction.None, transactionsLeft - 1, false);
                    break;
                case Transaction.ShortSelling:
                    UpdateAns(Transaction.None, transactionsLeft - 1, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return ans;

            void UpdateAns(Transaction nextTransaction, int nextTransactionLeft, bool isBuying)
            {
                var nextResult = recursiveFunc((day + 1, nextTransaction, nextTransactionLeft));

                if (nextResult == impossible)
                {
                    return;
                }

                var sign = isBuying ? -1 : 1;
                ans = Math.Max(ans, nextResult + prices[day] * sign);
            }
        });

        return dp.GetOrCalculate((0, Transaction.None, k));
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

    private enum Transaction
    {
        None,
        Normal,
        ShortSelling
    }
}
