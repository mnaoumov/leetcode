using JetBrains.Annotations;

namespace LeetCode._3129_Find_All_Possible_Stable_Binary_Arrays_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-129/submissions/detail/1243346369/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        var dp = new DynamicProgramming<(int value1Count, int value2Count), ModNumber>((key, recursiveFunc) =>
        {
            var (value1Count, value2Count) = key;

            if (value2Count == 0)
            {
                return value1Count <= limit ? 1 : 0;
            }

            ModNumber ans = 0;

            for (var i = 1; i <= Math.Min(limit, value1Count); i++)
            {
                ans += recursiveFunc((value2Count, value1Count - i));
            }

            return ans;
        });

        return dp.GetOrCalculate((zero, one)) + dp.GetOrCalculate((one, zero));
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
