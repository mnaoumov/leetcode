namespace LeetCode.Problems._2218_Maximum_Value_of_K_Coins_From_Piles;

/// <summary>
/// https://leetcode.com/submissions/detail/919882636/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxValueOfCoins(IList<IList<int>> piles, int k)
    {
        var dp = new DynamicProgramming<(int index, int coinsToTake), int>((key, recursiveFunc) =>
        {
            var (index, coinsToTake) = key;

            if (index == piles.Count || coinsToTake == 0)
            {
                return 0;
            }

            var result = 0;
            var pileSum = 0;

            for (var i = 0; i <= Math.Min(coinsToTake, piles[index].Count); i++)
            {
                if (i > 0)
                {
                    pileSum += piles[index][i - 1];
                }

                result = Math.Max(result, pileSum + recursiveFunc((index + 1, coinsToTake - i)));
            }

            return result;
        });

        return dp.GetOrCalculate((0, k));
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
