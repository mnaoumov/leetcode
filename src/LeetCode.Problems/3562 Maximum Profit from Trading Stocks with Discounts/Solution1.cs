namespace LeetCode.Problems._3562_Maximum_Profit_from_Trading_Stocks_with_Discounts;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-451/problems/maximum-profit-from-trading-stocks-with-discounts/submissions/1643656571/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget)
    {
        var children = Enumerable.Range(0, n + 1).Select(_ => new List<int>()).ToArray();
        var parents = new int[n + 1];

        foreach (var pair in hierarchy)
        {
            var u = pair[0];
            var v = pair[1];
            children[u].Add(v);
            parents[v] = u;
        }

        var order = new List<int>();
        var queue = new Queue<int>();
        queue.Enqueue(1);
        while (queue.Count > 0)
        {
            var u = queue.Dequeue();
            order.Add(u);
            foreach (var v in children[u])
            {
                queue.Enqueue(v);
            }
        }

        var dp = new DynamicProgramming<(int index, int budgetLeft, string purchasedEmployeeIndicesStr), int>((key, recursiveFunc) =>
        {
            var (index, budgetLeft, indicesPurchasedStr) = key;
            var purchasedEmployeeIndices = new SortedSet<int>(indicesPurchasedStr
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            if (index == n || budgetLeft == 0)
            {
                return 0;
            }

            var ans = recursiveFunc((index + 1, budgetLeft, indicesPurchasedStr));

            var employeeIndex = order[index];
            var supervisorIndex = parents[employeeIndex];

            var price = present[employeeIndex - 1];

            if (purchasedEmployeeIndices.Contains(supervisorIndex))
            {
                price /= 2;
            }

            if (budgetLeft < price)
            {
                return ans;
            }

            purchasedEmployeeIndices.Add(employeeIndex);
            var nextAns = future[employeeIndex - 1] - price + recursiveFunc((index + 1,
                budgetLeft - price, string.Join(' ', purchasedEmployeeIndices)));
            ans = Math.Max(ans, nextAns);
            return ans;
        });

        return dp.GetOrCalculate((0, budget, ""));
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
