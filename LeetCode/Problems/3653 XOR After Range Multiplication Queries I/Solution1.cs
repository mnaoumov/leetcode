using System.Numerics;

namespace LeetCode.Problems._3653_XOR_After_Range_Multiplication_Queries_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-463/problems/xor-after-range-multiplication-queries-i/submissions/1737972366/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        var modNums = nums.Select(num => (ModNumber) num).ToArray();

        foreach (var query in queries)
        {
            var l = query[0];
            var r = query[1];
            var k = query[2];
            var v = query[3];

            for (var i = l; i <= r; i += k)
            {
                modNums[i] *= v;
            }
        }

        return modNums.Aggregate(0, (current, modNum) => current ^ (int) modNum);
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
