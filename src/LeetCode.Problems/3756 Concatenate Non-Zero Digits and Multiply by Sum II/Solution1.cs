using System.Numerics;

namespace LeetCode.Problems._3756_Concatenate_Non_Zero_Digits_and_Multiply_by_Sum_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-477/problems/concatenate-non-zero-digits-and-multiply-by-sum-ii/submissions/1837319436/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SumAndMultiply(string s, int[][] queries)
    {
        var n = s.Length;
        var prefixNums = new List<ModNumber> { 0 };
        var prefixSums = new List<int> { 0 };
        var nonZeroIndices = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var digit = s[i] - '0';

            if (digit == 0)
            {
                continue;
            }

            prefixNums.Add(prefixNums[^1] * 10 + digit);
            prefixSums.Add(prefixSums[^1] + digit);
            nonZeroIndices.Add(i);
        }

        return queries.Select(arr => (int) Answer(arr[0], arr[1])).ToArray();

        ModNumber Answer(int l, int r)
        {
            l = nonZeroIndices.BinarySearch(l);

            if (l < 0)
            {
                l = ~l;
            }

            r = nonZeroIndices.BinarySearch(r);

            if (r < 0)
            {
                r = ~r - 1;
            }

            var num = prefixNums[r + 1] - prefixNums[l] * ModNumber.Pow(10, r - l + 1);
            var sum = prefixSums[r + 1] - prefixSums[l];
            return num * sum;
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

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
