using JetBrains.Annotations;

namespace LeetCode._1269_Number_of_Ways_to_Stay_in_the_Same_Place_After_Some_Steps;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumWays(int steps, int arrLen)
    {
        var deltas = new[] { -1, 0, 1 };

        var dp = new DynamicProgramming<(int index, int stepsLeft), ModNumber>((key, recursiveFunc) =>
        {
            var (index, stepsLeft) = key;

            if (index < 0 || index >= arrLen)
            {
                return 0;
            }

            if (stepsLeft == 0)
            {
                return index == 0 ? 1 : 0;
            }

            return deltas.Select(delta => recursiveFunc((index + delta, stepsLeft - 1))).Aggregate((x, y) => x + y);
        });

        return dp.GetOrCalculate((0, steps));
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
