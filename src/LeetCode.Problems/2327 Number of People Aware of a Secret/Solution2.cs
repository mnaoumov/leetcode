using System.Numerics;

namespace LeetCode.Problems._2327_Number_of_People_Aware_of_a_Secret;

/// <summary>
/// https://leetcode.com/problems/number-of-people-aware-of-a-secret/submissions/1764487858/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        var dp = new DynamicProgramming<(int day, int secretKnownDaysCount), ModNumber>((key, recursiveFunc) =>
        {
            var (day, secretKnownDaysCount) = key;

            if (day <= secretKnownDaysCount)
            {
                return 0;
            }

            if (day == 1)
            {
                return 1;
            }

            if (secretKnownDaysCount > 0)
            {
                return recursiveFunc((day - 1, secretKnownDaysCount - 1));
            }

            return ModNumber.Sum(Enumerable.Range(delay, forget - delay)
                .Select(secretKnownDaysCount2 => recursiveFunc((day - 1, secretKnownDaysCount2 - 1))));
        });

        return ModNumber.Sum(Enumerable.Range(0, forget)
            .Select(secretKnownDaysCount => dp.GetOrCalculate((n, secretKnownDaysCount))));
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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
