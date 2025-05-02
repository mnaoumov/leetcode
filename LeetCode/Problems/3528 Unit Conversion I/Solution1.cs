using System.Numerics;

namespace LeetCode.Problems._3528_Unit_Conversion_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-155/problems/unit-conversion-i/submissions/1618454395/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int[] BaseUnitConversions(int[][] conversions)
    {
        var n = conversions.Length + 1;
        var arr = new ModNumber[n];
        arr[0] = 1;

        var conversionObjs = conversions.Select(x => new Conversion(x[0], x[1], x[2]))
            .OrderBy(c => c.SourceUnit)
            .ToArray();

        foreach (var conversion in conversionObjs)
        {
            arr[conversion.TargetUnit] = arr[conversion.SourceUnit] * conversion.ConversionFactor;
        }

        return arr.Select(x => (int) x).ToArray();
    }

    private record Conversion(int SourceUnit, int TargetUnit, int ConversionFactor);

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
