using JetBrains.Annotations;

namespace LeetCode.Problems._0322_Coin_Change;

/// <summary>
/// https://leetcode.com/submissions/detail/882075552/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CoinChange(int[] coins, int amount)
    {
        Array.Sort(coins);

        var dp = new DynamicProgramming<int, int>((amount2, recursiveFunc) =>
        {
            if (amount2 == 0)
            {
                return 0;
            }

            const int impossible = -1;

            var result = 1 + coins.TakeWhile(coin => coin <= amount2)
                .Select(coin => recursiveFunc(amount2 - coin))
                .Where(subResult => subResult != impossible)
                .DefaultIfEmpty(impossible - 1)
                .Min();

            return result;
        });

        return dp.GetOrCalculate(amount);
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
