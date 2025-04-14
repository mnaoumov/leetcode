using System.Numerics;

namespace LeetCode.Problems._1922_Count_Good_Numbers;

/// <summary>
/// https://leetcode.com/problems/count-good-numbers/submissions/1605082369/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountGoodNumbers(long n)
    {
        const int evenDigitsCount = 5;
        const int primeDigitsCount = 4;
        return ModNumber.Pow(evenDigitsCount, (n + 1) / 2) * ModNumber.Pow(primeDigitsCount, n / 2);
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

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
