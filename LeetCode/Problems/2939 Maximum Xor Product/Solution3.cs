using System.Numerics;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2939_Maximum_Xor_Product;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-372/submissions/detail/1101809190/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
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
            var a2 = a1 ^ topBit;
            var b2 = b1 ^ topBit;

            if (a1 >= a2 && b1 >= b2)
            {
                return recursiveFunc((a1, b1, n1 - 1));
            }

            if (a2 >= a1 && b2 >= b1)
            {
                return recursiveFunc((a2, b2, n1 - 1));
            }

            return BigInteger.Max(
                recursiveFunc((a1, b1, n1 - 1)),
                recursiveFunc((a2, b2, n1 - 1))
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
