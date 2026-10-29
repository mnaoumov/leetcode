using System.Numerics;

namespace LeetCode.Problems._3623_Count_Number_of_Trapezoids_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-459/problems/count-number-of-trapezoids-i/submissions/1704204473/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountTrapezoids(int[][] points)
    {
        var pointObjs = points.Select(arr => new Point(arr[1])).ToArray();
        var pointCountsPerY = pointObjs.GroupBy(p => p.Y).Select(g => g.Count()).ToArray();
        var sideCounts = pointCountsPerY.Select(x => (ModNumber) 1 * x * (x - 1) / 2).ToArray();
        var sum = ModNumber.Sum(sideCounts);
        var sumSquares = ModNumber.Sum(sideCounts.Select(x => x * x));
        return (sum * sum - sumSquares) / 2;
    }

    private record Point(int Y);

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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
