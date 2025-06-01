namespace LeetCode.Problems._3562_Maximum_Profit_from_Trading_Stocks_with_Discounts;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget)
    {
        var subordinates = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();

        foreach (var pair in hierarchy)
        {
            var u = pair[0];
            var v = pair[1];
            subordinates[u].Add(v);
        }

        var dp = new DynamicProgramming<(int employeeId, int budgetLeft, bool hasDiscount), (int budget, int profit)>((key, recursiveFunc) =>
        {
            var (employeeId, budgetLeft, hasDiscount) = key;

            if (budgetLeft == 0)
            {
                return (0, 0);
            }

            var price = present[employeeId - 1] / (hasDiscount ? 2 : 1);

            var discountProfitPairs = new List<(bool isTaken, int profit)> { (false, 0) };

            if (budgetLeft >= price)
            {
                discountProfitPairs.Add((true, future[employeeId - 1] - price));
            }

            var entries = new List<(int budget, int profit)>();

            foreach (var (isTaken, profit) in discountProfitPairs)
            {
                var budgetLeft2 = budgetLeft- (isTaken ? price : 0);
                var maxProfit = profit;

                foreach (var subordinate in subordinates[employeeId])
                {
                    var next = recursiveFunc((subordinate, budgetLeft2, isTaken));
                    budgetLeft2 -= next.budget;
                    maxProfit += next.profit;
                }

                entries.Add((budgetLeft - budgetLeft2, maxProfit));
            }

            return entries.OrderByDescending(e => e.profit).First();
        });

        return dp.GetOrCalculate((1, budget, false)).profit;
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
