using System.Numerics;

namespace LeetCode.Problems._3333_Find_the_Original_Typed_String_II;

/// <summary>
/// https://leetcode.com/problems/find-the-original-typed-string-ii/submissions/1683266834/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int PossibleStringCount(string word, int k)
    {
        var repeatCounts = new List<int>();
        var lastLetter = '\0';

        foreach (var letter in word)
        {
            if (letter == lastLetter)
            {
                repeatCounts[^1]++;
            }
            else
            {
                lastLetter = letter;
                repeatCounts.Add(1);
            }
        }

        var unrestrictedCount = ModNumber.Multiply(repeatCounts.Select(c => (ModNumber) c));
        var m = repeatCounts.Count;

        var dp = new ModNumber[k];
        Array.Fill<ModNumber>(dp, 0);
        dp[0] = 1;

        for (var i = 0; i < m; i++)
        {
            var prefixSums = new ModNumber[k];
            Array.Fill<ModNumber>(prefixSums, 0);
            for (var j = 0; j < k; j++)
            {
                prefixSums[j] = (j == 0 ? 0 : prefixSums[j - 1]) + dp[j];
            }

            for (var j = k - 1; j >= 1; j--)
            {
                var low = j - repeatCounts[i] - 1;
                dp[j] = prefixSums[j - 1] - (low >= 0 ? prefixSums[low] : 0);
            }

            dp[0] = 0;
        }

        return unrestrictedCount - ModNumber.Sum(dp) + 1;
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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(1, (current, number) => current + number);

        public static ModNumber Multiply(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(1, (current, number) => current * number);

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
