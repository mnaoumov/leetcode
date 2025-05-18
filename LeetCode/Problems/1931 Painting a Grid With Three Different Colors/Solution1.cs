using System.Numerics;
using System.Text;

namespace LeetCode.Problems._1931_Painting_a_Grid_With_Three_Different_Colors;

/// <summary>
/// https://leetcode.com/problems/painting-a-grid-with-three-different-colors/submissions/1636832410/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int ColorTheGrid(int m, int n)
    {
        const char red = 'R';
        const char green = 'G';
        const char blue = 'B';
        const char unset = ' ';
        var unsetColumn = new string(unset, m);

        var colors = new[] { red, green, blue };

        var dp = new DynamicProgramming<(int i, int j, string previousColumnColorStr, string currentColumnColorStr), ModNumber>((key, recursiveFunc) =>
        {
            var (i, j, previousColumnColorStr, currentColumnColorStr) = key;

            if (j == n)
            {
                return 1;
            }

            if (i == m)
            {
                return recursiveFunc((0, j + 1, currentColumnColorStr, unsetColumn));
            }

            var sb = new StringBuilder(currentColumnColorStr);

            ModNumber ans = 0;

            foreach (var color in colors)
            {
                if (previousColumnColorStr[i] == color || i > 0 && currentColumnColorStr[i - 1] == color)
                {
                    continue;
                }

                sb[i] = color;
                ans += recursiveFunc((i + 1, j, previousColumnColorStr, sb.ToString()));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, unsetColumn, unsetColumn));
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
