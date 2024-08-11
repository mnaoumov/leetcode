using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._3250_Find_the_Count_of_Monotonic_Pairs_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-410/submissions/detail/1351575729/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountOfPairs(int[] nums)
    {
        var n = nums.Length;
        var sum = nums[^1];

        for (var i = 1; i < n; i++)
        {
            var diff = Math.Max(0, nums[i] - nums[i - 1]);
            sum -= diff;

            if (sum < 0)
            {
                return 0;
            }
        }

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

        return Choose(sum + n, n);

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

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
