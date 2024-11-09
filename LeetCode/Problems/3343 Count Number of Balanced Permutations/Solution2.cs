using System.Numerics;

namespace LeetCode.Problems._3343_Count_Number_of_Balanced_Permutations;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
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

        var digitCounts = new int[10];

        foreach (var digit in digits)
        {
            digitCounts[digit]++;
        }

        var n = digits.Length;

        var factorialDp =
            new DynamicProgramming<int, ModNumber>((a, recursiveFunc) => a == 0 ? 1 : a * recursiveFunc(a - 1));
        var inverseDp = new DynamicProgramming<int, ModNumber>((a, _) =>
        {
            if (a == 1)
            {
                return 1;
            }

            return ((ModNumber) a).Inverse();
        });
        var inverseFactorialDp =
            new DynamicProgramming<int, ModNumber>((a, recursiveFunc) =>
                a == 0 ? 1 : Inverse(a) * recursiveFunc(a - 1));

        var dp = new DynamicProgramming<(int digitsLeft1, int digitsLeft2, int sumLeft1, int sumLeft2, string digitCountsStr), ModNumber>((key, recursiveFunc) =>
        {
            var (digitsLeft1, digitsLeft2, sumLeft1, sumLeft2, digitCountsStr) = key;

            if (digitsLeft1 == 0 && sumLeft1 != 0)
            {
                return 0;
            }

            if (digitsLeft2 == 0 && sumLeft2 != 0)
            {
                return 0;
            }

            if (digitsLeft1 == 0 && digitsLeft2 == 0)
            {
                return 1;
            }

            var digitCountsArr = digitCountsStr.Split(' ').Select(int.Parse).ToArray();

            var digit = Enumerable.Range(0, 10).First(d => digitCountsArr[d] > 0);

            var max1 = new[]
            {
                digitCountsArr[digit],
                digitsLeft1,
                digit == 0 ? int.MaxValue : sumLeft1 / digit
            }.Min();

            var max2 = new[]
            {
                digitCountsArr[digit],
                digitsLeft2,
                digit == 0 ? int.MaxValue : sumLeft2 / digit
            }.Min();

            if (max1 + max2 < digitCountsArr[digit])
            {
                return 0;
            }

            ModNumber ans = 0;

            for (var taken1 = digitCountsArr[digit] - max2; taken1 <= max1; taken1++)
            {
                var taken2 = digitCountsArr[digit] - taken1;
                digitCountsArr[digit] = 0;
                ans +=
                    Choose(digitsLeft1, taken1)
                    * Choose(digitsLeft2, taken2)
                    * recursiveFunc((
                        digitsLeft1 - taken1,
                        digitsLeft2 - taken2,
                        sumLeft1 - digit * taken1,
                        sumLeft2 - digit * taken2,
                        string.Join(' ', digitCountsArr)));
                digitCountsArr[digit] = taken1 + taken2;
            }

            return ans;
        });

        return dp.GetOrCalculate(((n + 1) / 2, n / 2, sum / 2, sum / 2, string.Join(' ', digitCounts)));

        ModNumber Choose(int a, int b) => Factorial(a) * InverseFactorial(b) * InverseFactorial(a - b);
        ModNumber Factorial(int a) => factorialDp.GetOrCalculate(a);
        ModNumber InverseFactorial(int a) => inverseFactorialDp.GetOrCalculate(a);
        ModNumber Inverse(int a) => inverseDp.GetOrCalculate(a);
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public ModNumber Inverse() => (int) BigInteger.ModPow(_value, Modulo - 2, Modulo);

        public override string ToString() => _value.ToString();
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
}
