using System.Numerics;

namespace LeetCode.Problems._2939_Maximum_Xor_Product;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-372/submissions/detail/1101804445/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaximumXorProduct(long a, long b, int n)
    {
        var dp = new DynamicProgramming<(long a1, long b1, int n1), BigInteger>((key, recursiveFunc) =>
        {
            var (a1, b1, n1) = key;

            if (n1 == 0)
            {
                return BigInteger.One * a1 * b1;
            }

            var topBit = 1 << n1 - 1;
            return BigInteger.Max(
                recursiveFunc((a1, b1, n1 - 1)),
                recursiveFunc((a1 ^ topBit, b1 ^ topBit, n1 - 1))
            );
        });

        const int modulo = 1_000_000_007;
        return (int) (dp.GetOrCalculate((a, b, n)) % modulo);
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
