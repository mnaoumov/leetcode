using System.Numerics;

namespace LeetCode.Problems._3405_Count_the_Number_of_Arrays_with_K_Matching_Adjacent_Elements;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-arrays-with-k-matching-adjacent-elements/submissions/1666678351/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int CountGoodArrays(int n, int m, int k) => m * Choose(n - 1, k) * ModNumber.Pow(m - 1, n - 1 - k);

    private static ModNumber Choose(int n, int k)
    {
        k = Math.Min(k, n - k);

        ModNumber ans = 1;

        for (var i = 0; i < k; i++)
        {
            ans *= n - i;
            ans /= i + 1;
        }

        return ans;
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

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
