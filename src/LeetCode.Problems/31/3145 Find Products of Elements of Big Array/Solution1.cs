using System.Numerics;

namespace LeetCode.Problems._3145_Find_Products_of_Elements_of_Big_Array;

/// <summary>
/// NotImplemented
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int[] FindProductsOfElements(long[][] queries)
    {
        const int maxBit = 50; // <= 10^15
        var totalCountByPower = new long[maxBit];
        totalCountByPower[0] = 1;

        for (var i = 1; i < maxBit; i++)
        {
            totalCountByPower[i] = (1L << i) + 2 * totalCountByPower[i];
        }

        var totalPowerOfTwoDp = new DynamicProgramming<long, long>((_, _) => 0);

        return queries.Select(query => Calculate(query[0], query[1], query[2])).ToArray();

        int Calculate(long from, long to, long mod)
        {
            var totalPowerOfTwo = totalPowerOfTwoDp.GetOrCalculate(to) - totalPowerOfTwoDp.GetOrCalculate(from - 1);
            return (int) BigInteger.ModPow(2, totalPowerOfTwo, mod);
        }
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
