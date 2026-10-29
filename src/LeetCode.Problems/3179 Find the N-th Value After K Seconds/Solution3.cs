using System.Numerics;

namespace LeetCode.Problems._3179_Find_the_N_th_Value_After_K_Seconds;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-401/submissions/detail/1282320692/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int ValueAfterKSeconds(int n, int k)
    {
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

        return Choose(n + k - 1, k);

        ModNumber Choose(int a, int b) => Factorial(a) * InverseFactorial(b) * InverseFactorial(a - b);

        ModNumber Factorial(int a) => factorialDp.GetOrCalculate(a);
        ModNumber InverseFactorial(int a) => inverseFactorialDp.GetOrCalculate(a);
        ModNumber Inverse(int a) => inverseDp.GetOrCalculate(a);

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

        public override string ToString() => _value.ToString();

        public ModNumber Inverse() => (int) BigInteger.ModPow(_value, Modulo - 2, Modulo);
    }
}
