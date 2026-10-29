using System.Numerics;

namespace LeetCode.Problems._3343_Count_Number_of_Balanced_Permutations;

/// <summary>
/// https://leetcode.com/problems/count-number-of-balanced-permutations/submissions/1630203365/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int CountBalancedPermutations(string num)
    {
        var digits = num.Select(symbol => symbol - '0').ToArray();
        var sum = digits.Sum();

        if (sum % 2 != 0)
        {
            return 0;
        }

        var originalDigitCounts = new int[10];

        foreach (var digit in digits)
        {
            originalDigitCounts[digit]++;
        }

        var n = digits.Length;
        var evenIndexMaxCount = (n + 1) / 2;
        var oddIndexMaxCount = n / 2;

        var factorials = new ModNumber[oddIndexMaxCount + 1];
        factorials[0] = 1;

        for (var i = 1; i <= oddIndexMaxCount; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }

        var dp = new DynamicProgramming<(int evenIndexCount, int sumLeft, string digitCountsStr), ModNumber>((key, recursiveFunc) =>
        {
            var (evenIndexCount, sumLeft, digitCountsStr) = key;

            var digitCounts = digitCountsStr.Split(' ').Select(int.Parse).ToArray();

            if (evenIndexCount == evenIndexMaxCount)
            {
                return sumLeft == 0 ? GetOddCount(digitCounts) : 0;
            }

            ModNumber ans = 0;

            for (var digit = 0; digit <= 9; digit++)
            {
                if (digitCounts[digit] == 0)
                {
                    continue;
                }

                if (sumLeft < digit)
                {
                    continue;
                }

                digitCounts[digit]--;
                ans += recursiveFunc((evenIndexCount + 1, sumLeft - digit, string.Join(' ', digitCounts)));
                digitCounts[digit]++;
            }

            return ans;
        });

        return dp.GetOrCalculate((0, sum / 2, string.Join(' ', originalDigitCounts)));

        ModNumber GetOddCount(int[] digitCounts) => digitCounts.Aggregate(factorials[oddIndexMaxCount],
            (current, digitCount) => current / factorials[digitCount]);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
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
