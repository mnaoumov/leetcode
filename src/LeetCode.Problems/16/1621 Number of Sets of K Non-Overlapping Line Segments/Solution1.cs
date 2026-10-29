using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._1621_Number_of_Sets_of_K_Non_Overlapping_Line_Segments;

/// <summary>
/// https://leetcode.com/problems/number-of-sets-of-k-non-overlapping-line-segments/submissions/2143259010/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSets(int n, int k)
    {
        var dp = new DynamicProgramming<(int index, int intervalsLeft, bool isStarted), ModNumber>((key, getOrCalculate) =>
        {
            var (index, intervalsLeft, isStarted) = key;

            if (n - 1 - index + (isStarted ? 1 : 0) < intervalsLeft)
            {
                return 0;
            }

            if (intervalsLeft == 0)
            {
                return 1;
            }

            var ans = getOrCalculate((index + 1, intervalsLeft, isStarted));

            if (isStarted)
            {
                ans += getOrCalculate((index, intervalsLeft - 1, false));
            }
            else
            {
                ans += getOrCalculate((index + 1, intervalsLeft, true));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, k, false));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private sealed class ModNumber
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

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
