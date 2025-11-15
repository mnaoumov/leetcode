using System.Numerics;

namespace LeetCode.Problems._3725_Count_Ways_to_Choose_Coprime_Integers_from_Rows;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-168/problems/count-ways-to-choose-coprime-integers-from-rows/submissions/1811395434/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int CountCoprime(int[][] mat)
    {
        var primes = new[]
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149
        };

        var m = mat.Length;
        var n = mat[0].Length;

        if (m == 1)
        {
            return Enumerable.Range(0, n).Count(column => mat[0][column] == 1);
        }

        var factorMaskDp = new DynamicProgramming<int, long>((num, _) =>
        {
            var ans = 0L;

            for (var i = 0; i < primes.Length; i++)
            {
                var prime = primes[i];
                var hasPrime = false;
                while (num % prime == 0)
                {
                    num /= prime;
                    hasPrime = true;
                }

                if (hasPrime)
                {
                    ans ^= (1L << i);
                }

                if (num == 1)
                {
                    break;
                }
            }

            return ans;
        });

        var dp = new DynamicProgramming<(int row, long mask), ModNumber>((key, getOrCalculate) =>
        {
            var (row, mask) = key;
            if (row == m)
            {
                return 1;
            }

            ModNumber ans = 0;

            for (var column = 0; column < n; column++)
            {
                var factorMask = factorMaskDp.GetOrCalculate(mat[row][column]);

                if ((factorMask & mask) != 0)
                {
                    continue;
                }

                ans += getOrCalculate((row + 1, factorMask | mask));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
