namespace LeetCode.Problems._3562_Maximum_Profit_from_Trading_Stocks_with_Discounts;

/// <summary>
/// https://leetcode.com/problems/maximum-profit-from-trading-stocks-with-discounts/submissions/1856759248/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget)
    {
        var subordinates = new Dictionary<int, List<int>>();

        foreach (var h in hierarchy)
        {
            var u = h[0];
            var v = h[1];
            subordinates.TryAdd(u, new List<int>());
            subordinates[u].Add(v);
        }

        var dp = new DynamicProgramming<(int employeeId, bool hasDiscount), Dictionary<int, int>>((key, getOrCalculate) =>
        {
            var (employeeId, hasDiscount) = key;
            var price = present[employeeId - 1];

            if (hasDiscount)
            {
                price /= 2;
            }

            var dict = new Dictionary<(int employeeBudget, bool didBuyStock), int>
            {
                [(0, false)] = 0
            };

            if (price <= budget)
            {
                dict[(price, true)] = future[employeeId - 1] - price;
            }

            foreach (var subordinateId in subordinates.GetValueOrDefault(employeeId, new List<int>()))
            {
                foreach (var (key2, employeeProfit) in dict.ToArray())
                {
                    var subordinateResult = getOrCalculate((subordinateId, key2.didBuyStock));

                    foreach (var (subordinateBudget, subordinateProfit) in subordinateResult)
                    {
                        var key3 = (employeeBudget: key2.employeeBudget + subordinateBudget, key2.didBuyStock);
                        if (key3.employeeBudget > budget)
                        {
                            continue;
                        }
                        dict.TryAdd(key3, int.MinValue);
                        dict[key3] = Math.Max(dict[key3], employeeProfit + subordinateProfit);
                    }
                }
            }

            var ans = new Dictionary<int, int>();

            foreach (var (key2, employeeProfit) in dict)
            {
                ans.TryAdd(key2.employeeBudget, int.MinValue);
                ans[key2.employeeBudget] = Math.Max(ans[key2.employeeBudget], employeeProfit);
            }
            return ans;
        });


        return dp.GetOrCalculate((1, false)).Values.Max();
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
