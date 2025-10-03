using System.Numerics;

namespace LeetCode.Problems._3699_Number_of_ZigZag_Arrays_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-469/problems/number-of-zigzag-arrays-i/submissions/1784873599/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        var counts = new Dictionary<(int lastValue, Direction direction), ModNumber>();
        var smallerCounts = new Dictionary<(int lastValue, Direction direction), ModNumber>();
        var greaterCounts = new Dictionary<(int lastValue, Direction direction), ModNumber>();

        for (var i = l; i <= r; i++)
        {
            foreach (var direction in Enum.GetValues<Direction>())
            {
                counts[(i, direction)] = 1;
                smallerCounts[(i, direction)] = i - l;
                greaterCounts[(i, direction)] = r - i;
            }
        }

        for (var j = 1; j < n; j++)
        {
            for (var i = l; i <= r; i++)
            {
                counts[(i, Direction.Increasing)] = smallerCounts[(i, Direction.Decreasing)];
                counts[(i, Direction.Decreasing)] = greaterCounts[(i, Direction.Increasing)];

                foreach (var direction in Enum.GetValues<Direction>())
                {
                    smallerCounts[(i, direction)] =
                        i == l ? 0 : smallerCounts[(i - 1, direction)] + counts[(i - 1, direction)];
                }
            }

            for (var i = r; i >= l; i--)
            {
                foreach (var direction in Enum.GetValues<Direction>())
                {
                    greaterCounts[(i, direction)] =
                        i == r ? 0 : greaterCounts[(i + 1, direction)] + counts[(i + 1, direction)];
                }
            }
        }

        return greaterCounts[(l, Direction.Increasing)]
               + greaterCounts[(l, Direction.Decreasing)]
               + counts[(l, Direction.Increasing)]
               + counts[(l, Direction.Decreasing)];
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

    private enum Direction
    {
        Increasing,
        Decreasing
    }
}
