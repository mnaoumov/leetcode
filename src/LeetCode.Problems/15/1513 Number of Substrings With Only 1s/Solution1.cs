using System.Numerics;

namespace LeetCode.Problems._1513_Number_of_Substrings_With_Only_1s;

/// <summary>
/// https://leetcode.com/problems/number-of-substrings-with-only-1s/submissions/1830965206/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSub(string s)
    {
        var oneSequenceLengths = new List<int>();

        var isOneSequence = false;

        foreach (var symbol in s)
        {
            if (symbol == '0')
            {
                isOneSequence = false;
            }
            else
            {
                if (isOneSequence)
                {
                    oneSequenceLengths[^1]++;
                }
                else
                {
                    oneSequenceLengths.Add(1);
                }
                isOneSequence = true;
            }
        }

        return ModNumber.Sum(oneSequenceLengths.Select(x => (ModNumber) (1L * x * (x + 1) / 2)));
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator ModNumber(long value) => new(value);
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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
