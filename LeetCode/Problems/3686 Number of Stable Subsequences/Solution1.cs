using System.Numerics;

namespace LeetCode.Problems._3686_Number_of_Stable_Subsequences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-467/problems/number-of-stable-subsequences/submissions/1770035234/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountStableSubsequences(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, bool? previousParity, bool? previousParity2), ModNumber>((key, recursiveFunc) =>
        {
            var (index, previousParity, previousParity2) = key;

            if (index == n)
            {
                return 0;
            }

            var ans = recursiveFunc((index + 1, previousParity, previousParity2));

            var parity = nums[index] % 2 == 0;

            if (previousParity != previousParity2 || previousParity != parity)
            {
                ans += 1 + recursiveFunc((index + 1, parity, previousParity));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, null, null));
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
