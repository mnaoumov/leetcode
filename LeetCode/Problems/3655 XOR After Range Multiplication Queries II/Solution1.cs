using System.Globalization;
using System.Numerics;

namespace LeetCode.Problems._3655_XOR_After_Range_Multiplication_Queries_II;

/// <summary>
/// https://leetcode.com/problems/xor-after-range-multiplication-queries-ii/submissions/1973199520/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        var n = nums.Length;
        var m = (int) Math.Floor(Math.Sqrt(n));
        var queryObjs = queries.Select(arr => new Query(arr[0], arr[1], arr[2], arr[3])).ToArray();
        var arr = nums.Select(num => (ModNumber) num).ToArray();

        foreach (var grouping in queryObjs.GroupBy(q => q.Step))
        {
            var step = grouping.Key;

            if (step >= m)
            {
                foreach (var query in grouping)
                {
                    for (var i = query.LeftIndex; i <= query.RightIndex; i += step)
                    {
                        arr[i] *= query.Multiplicator;
                    }
                }
            }
            else
            {
                var multipliers = new ModNumber[n];
                Array.Fill(multipliers, (ModNumber) 1);

                foreach (var query in grouping)
                {
                    multipliers[query.LeftIndex] *= query.Multiplicator;
                    var extraStepCount = (query.RightIndex - query.LeftIndex + step) / step;
                    var extraIndex = query.LeftIndex + extraStepCount * step;

                    if (extraIndex < n)
                    {
                        multipliers[extraIndex] /= query.Multiplicator;
                    }
                }

                for (var i = 0; i < n; i++)
                {
                    if (i >= step)
                    {
                        multipliers[i] *= multipliers[i - step];
                    }

                    arr[i] *= multipliers[i];
                }
            }
        }

        return arr.Aggregate((a, b) => a ^ b);
    }

    private sealed record Query(int LeftIndex, int RightIndex, int Step, int Multiplicator);

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

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }

}
