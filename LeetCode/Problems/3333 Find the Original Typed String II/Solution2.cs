using System.Numerics;

namespace LeetCode.Problems._3333_Find_the_Original_Typed_String_II;

/// <summary>
/// https://leetcode.com/problems/find-the-original-typed-string-ii/submissions/1683271075/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int PossibleStringCount(string word, int k)
    {
        var repeatCounts = new List<int>();
        var lastLetter = '\0';

        foreach (var letter in word)
        {
            if (letter == lastLetter)
            {
                repeatCounts[^1]++;
            }
            else
            {
                lastLetter = letter;
                repeatCounts.Add(1);
            }
        }

        var unrestrictedCount = ModNumber.Multiply(repeatCounts.Select(c => (ModNumber) c));
        if (repeatCounts.Count >= k)
        {
            return unrestrictedCount;
        }

        var g = new ModNumber[k];
        Array.Fill<ModNumber>(g, 1);
        foreach (var count in repeatCounts)
        {
            var f = new ModNumber[k];
            Array.Fill<ModNumber>(f, 0);
            for (var j = 1; j < k; j++)
            {
                f[j] = g[j - 1];
                if (j - count - 1 >= 0)
                {
                    f[j] -= g[j - count - 1];
                }
            }

            var gNext = new ModNumber[k];
            Array.Fill<ModNumber>(gNext, 0);
            gNext[0] = f[0];
            for (var j = 1; j < k; ++j)
            {
                gNext[j] = gNext[j - 1] + f[j];
            }

            g = gNext;
        }

        return unrestrictedCount - g[k - 1];
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

        public static ModNumber Multiply(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(1, (current, number) => current * number);

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}