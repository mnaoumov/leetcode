using System.Numerics;

namespace LeetCode.Problems._3337_Total_Characters_in_String_After_Transformations_II;

/// <summary>
/// https://leetcode.com/problems/total-characters-in-string-after-transformations-ii/submissions/1633390541/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    private const int LettersCount = 26;

    public int LengthAfterTransformations(string s, int t, IList<int> nums)
    {
        var matrix = new Matrix(LettersCount, LettersCount);

        for (var i = 0; i < LettersCount; i++)
        {
            var num = nums[i];

            for (var j = 1; j <= num; j++)
            {
                matrix[i, (i + j) % LettersCount]++;
            }
        }

        var sVector = new Matrix(LettersCount, 1);

        foreach (var letter in s)
        {
            sVector[letter - 'a', 0]++;
        }

        return matrix.Power(t).Multiply(sVector).Sum();
    }

    private class Matrix
    {
        private readonly ModNumber[,] _values;

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _values = new ModNumber[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    _values[row, column] = 0;
                }
            }
        }

        private int Columns { get; }

        private int Rows { get; }

        public ModNumber this[int row, int column]
        {
            get => _values[row, column];
            set => _values[row, column] = value;
        }

        public Matrix Power(int exponent)
        {
            if (Rows != Columns)
            {
                throw new InvalidOperationException("Matrix must be square.");
            }

            if (exponent == 1)
            {
                return this;
            }

            var matrix2 = Power(exponent / 2);
            var ans = matrix2.Multiply(matrix2);
            if (exponent % 2 == 1)
            {
                ans = ans.Multiply(this);
            }

            return ans;
        }

        public Matrix Multiply(Matrix matrix)
        {
            if (Columns != matrix.Rows)
            {
                throw new InvalidOperationException("Matrix dimensions do not match for multiplication.");
            }

            var ans = new Matrix(Rows, matrix.Columns);

            for (var row = 0; row < ans.Rows; row++)
            {
                for (var column = 0; column < ans.Columns; column++)
                {
                    for (var column2 = 0; column2 < Columns; column2++)
                    {
                        ans[row, column] += this[row, column2] * matrix[column2, column];
                    }
                }
            }

            return ans;
        }

        public ModNumber Sum()
        {
            ModNumber ans = 0;

            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    ans += this[row, column];
                }
            }

            return ans;
        }
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
