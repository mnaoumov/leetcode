using JetBrains.Annotations;

namespace LeetCode.Problems._3179_Find_the_N_th_Value_After_K_Seconds;

/// <summary>
/// https://leetcode.com/submissions/detail/1282290322/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int ValueAfterKSeconds(int n, int k)
    {
        var chooseDp = new DynamicProgramming<(int a, int b), ModNumber>((key, recursiveFunc) =>
        {
            var (a, b) = key;

            if (b == 0)
            {
                return 1;
            }

            if (a == 0)
            {
                return 0;
            }

            if (a - b < b)
            {
                return recursiveFunc((a, a - b));
            }

            return recursiveFunc((a - 1, b - 1)) + recursiveFunc((a - 1, b));
        });

        return chooseDp.GetOrCalculate((n + k - 1, k));
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
