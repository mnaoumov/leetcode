using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._0000_Sum_of_K_Digit_Numbers_in_a_Range;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-177/problems/sum-of-k-digit-numbers-in-a-range/submissions/1933835908/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfNumbers(int l, int r, int k) => (ModNumber.Pow(10, k) - 1) / 9 * (l + r) * (r - l + 1) / 2 * ModNumber.Pow(r - l + 1, k - 1);

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

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
