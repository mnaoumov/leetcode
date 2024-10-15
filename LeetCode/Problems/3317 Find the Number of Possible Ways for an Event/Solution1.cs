using System.Numerics;

namespace LeetCode.Problems._100450_Find_the_Number_of_Possible_Ways_for_an_Event;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int NumberOfWays(int n, int x, int y)
    {
        ModNumber ans = 0;

        var factorialDp =
            new DynamicProgramming<int, ModNumber>((num, recursiveFunc) =>
                num == 0 ? 1 : num * recursiveFunc(num - 1));
        var inverseFactorialDp =
            new DynamicProgramming<int, ModNumber>((num, recursiveFunc) =>
                num == 0 ? 1 : ((ModNumber) num).Inverse() * recursiveFunc(num - 1));
        var stirlingDp =
            new DynamicProgramming<(int a, int b), ModNumber>((key, recursiveFunc) =>
            {
                var (a, b) = key;

                if (a == 0 && b == 0)
                {
                    return 1;
                }

                if (a == 0 || b == 0)
                {
                    return 0;
                }

                return b * recursiveFunc((a - 1, b)) + recursiveFunc((a - 1, b - 1));
            });

        for (var k = 1; k <= x; k++)
        {
            ans += ModNumber.Pow(y, k) * factorialDp.GetOrCalculate(x) / inverseFactorialDp.GetOrCalculate(x - k) *
                   stirlingDp.GetOrCalculate((n, k));
        }

        return ans;
    }

    private class ModNumber
    {
        private const int Modulus = 1_000_000_007;
        private readonly int _value;


        private ModNumber(BigInteger value) : this((long) (value % Modulus)) { }

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulus);

        private static int Mod(long value) => (int) (value % Modulus);

        public static implicit operator ModNumber(BigInteger value) => new(value);
        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber Pow(ModNumber modNumber, ModNumber power) =>
            BigInteger.ModPow(modNumber._value, power._value, Modulus);

        public ModNumber Inverse() => BigInteger.ModPow(_value, Modulus - 2, Modulus);

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
