using System.Numerics;

namespace LeetCode.Problems._3577_Count_the_Number_of_Computer_Unlocking_Permutations;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-computer-unlocking-permutations/submissions/1852459424/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPermutations(int[] complexity)
    {
        var isValid = complexity.Skip(1).All(c => c > complexity[0]);
        var n = complexity.Length;
        return isValid ? Factorial(n - 1) : 0;
    }

    private static ModNumber Factorial(int n)
    {
        ModNumber ans = 1;
        for (var i = 1; i <= n; i++)
        {
            ans *= i;
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

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
