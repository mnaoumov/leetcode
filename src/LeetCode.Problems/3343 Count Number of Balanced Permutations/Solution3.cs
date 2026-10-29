using System.Numerics;

namespace LeetCode.Problems._3343_Count_Number_of_Balanced_Permutations;

/// <summary>
/// https://leetcode.com/problems/count-number-of-balanced-permutations/submissions/1630233219/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
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

        var factorials = new ModNumber[evenIndexMaxCount + 1];
        factorials[0] = 1;

        for (var i = 1; i <= evenIndexMaxCount; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }

        var dp = new DynamicProgramming<(int digit, int digitsLeft, int sumLeft, string digitCountsStr), ModNumber>((key, recursiveFunc) =>
        {
            var (digit, digitsLeft, sumLeft, digitCountsStr) = key;

            var digitCounts = digitCountsStr.Split(' ').Select(int.Parse).ToArray();

            ModNumber ans = 0;

            if (digit == 10)
            {
                if (sumLeft != 0 || digitsLeft != 0)
                {
                    return 0;
                }

                ans = factorials[evenIndexMaxCount] * factorials[oddIndexMaxCount];

                for (var digit2 = 0; digit2 <= 9; digit2++)
                {
                    ans /= factorials[digitCounts[digit2]];
                    ans /= factorials[originalDigitCounts[digit2] - digitCounts[digit2]];
                }

                return ans;
            }

            for (var count = 0; count <= digitCounts[digit]; count++)
            {
                if (sumLeft < digit * count || digitsLeft < count)
                {
                    break;
                }

                digitCounts[digit] -= count;
                ans += recursiveFunc((digit + 1, digitsLeft - count, sumLeft - digit * count, string.Join(' ', digitCounts)));
                digitCounts[digit] += count;
            }

            return ans;
        });

        return dp.GetOrCalculate((0, evenIndexMaxCount, sum / 2, string.Join(' ', originalDigitCounts)));
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
