namespace LeetCode.Problems._0465_Optimal_Account_Balancing;

/// <summary>
/// https://leetcode.com/submissions/detail/984117670/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinTransfers(int[][] transactions)
    {
        var balances = new Dictionary<int, int>();

        foreach (var transaction in transactions)
        {
            var from = transaction[0];
            var to = transaction[1];
            var amount = transaction[2];

            balances.TryAdd(from, 0);
            balances.TryAdd(to, 0);
            balances[from] -= amount;
            balances[to] += amount;
        }

        var people = balances.Keys.Where(person => balances[person] != 0).ToArray();
        var n = people.Length;

        var groupCountDp = new DynamicProgramming<int, int>((peopleMask, recursiveFunc) =>
        {
            if (peopleMask == 0)
            {
                return 0;
            }

            var ans = 0;
            var balance = 0;

            for (var i = 0; i < n; i++)
            {
                if ((peopleMask & 1 << i) == 0)
                {
                    continue;
                }

                ans = Math.Max(ans, recursiveFunc(peopleMask ^ 1 << i));
                balance += balances[people[i]];
            }

            if (balance == 0)
            {
                ans++;
            }

            return ans;
        });

        return n - groupCountDp.GetOrCalculate((1 << n) - 1);
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
