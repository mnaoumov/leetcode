using System.Globalization;

namespace LeetCode.Problems._3129_Find_All_Possible_Stable_Binary_Arrays_I;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        var dp = new DynamicProgramming<(int zeroCounts, int oneCounts), ModNumber>((key, getOrCalculate) =>
        {
            var (zeroCounts, oneCounts) = key;

            if (zeroCounts == 0 && oneCounts == 0)
            {
                return 0;
            }

            if ((zeroCounts == 0 || oneCounts == 0))
            {
                return zeroCounts + oneCounts > limit ? 0 : 1;
            }

            ModNumber ans = 0;

            if (zeroCounts > 0)
            {
                ans += getOrCalculate((zeroCounts - 1, oneCounts));
            }

            if (oneCounts > 0)
            {
                ans += getOrCalculate((zeroCounts, oneCounts - 1));
            }

            return ans;
        });

        return dp.GetOrCalculate((zero, one));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

    private sealed class ModNumber
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

        public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
    }
}
