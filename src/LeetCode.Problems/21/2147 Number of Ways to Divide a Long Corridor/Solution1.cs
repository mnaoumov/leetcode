namespace LeetCode.Problems._2147_Number_of_Ways_to_Divide_a_Long_Corridor;

/// <summary>
/// https://leetcode.com/submissions/detail/1107785007/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int NumberOfWays(string corridor)
    {
        var n = corridor.Length;
        const char seat = 'S';

        var dp = new DynamicProgramming<int, ModNumber>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 1;
            }

            var seatCount = 0;
            ModNumber ans = 0;

            for (var i = index; i < n; i++)
            {
                if (corridor[i] == seat)
                {
                    seatCount++;

                    if (seatCount == 3)
                    {
                        break;
                    }
                }

                if (seatCount == 2)
                {
                    ans += recursiveFunc(i + 1);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate(0);
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
