using JetBrains.Annotations;

namespace LeetCode.Problems._0629_K_Inverse_Pairs_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1158717699/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int KInversePairs(int n, int k)
    {
        var dp = new DynamicProgramming<(int numbersLeft, int inversePairsCount), ModNumber>((key, recursiveFunc) =>
        {
            var (numbersLeft, inversePairsCount) = key;

            if (inversePairsCount == 0)
            {
                return 1;
            }

            if (inversePairsCount > numbersLeft * (numbersLeft - 1) / 2)
            {
                return 0;
            }

            return recursiveFunc((numbersLeft, inversePairsCount - 1)) +
                   recursiveFunc((numbersLeft - 1, inversePairsCount)) -
                   (inversePairsCount - numbersLeft >= 0
                       ? recursiveFunc((numbersLeft - 1, inversePairsCount - numbersLeft))
                       : 0);
        });

        return dp.GetOrCalculate((n, k));
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
    }
}
