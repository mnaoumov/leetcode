using JetBrains.Annotations;

namespace LeetCode._0518_Coin_Change_II;

/// <summary>
/// https://leetcode.com/submissions/detail/920400059/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Change(int amount, int[] coins)
    {
        Array.Sort(coins);
        var dp = new DynamicProgramming<(int index, int amountLeft), int>((key, recursiveFunc) =>
        {
            var (index, amountLeft) = key;

            if (amountLeft == 0)
            {
                return 1;
            }

            if (index == coins.Length)
            {
                return 0;
            }

            if (coins[index] > amountLeft)
            {
                return 0;
            }

            var result = 0;

            while (amountLeft >= 0)
            {
                result += recursiveFunc((index + 1, amountLeft));
                amountLeft -= coins[index];
            }

            return result;
        });

        return dp.GetOrCalculate((0, amount));
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
