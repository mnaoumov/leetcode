using JetBrains.Annotations;

namespace LeetCode._3129_Find_All_Possible_Stable_Binary_Arrays_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-129/submissions/detail/1243326750/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        var dp = new DynamicProgramming<(int value1Count, int value2Count, int maxSequentialValue1CountAllowed), ModNumber>((key, recursiveFunc) =>
        {
            var (value1Count, value2Count, maxSequentialValue1CountAllowed) = key;

            if (value1Count == 0 && value2Count == 0)
            {
                return 1;
            }

            ModNumber ans = 0;

            if (maxSequentialValue1CountAllowed > 0 && value1Count > 0)
            {
                ans += recursiveFunc((value1Count - 1, value2Count, maxSequentialValue1CountAllowed - 1));
            }

            if (value2Count > 0)
            {
                ans += recursiveFunc((value2Count - 1, value1Count, limit - 1));
            }
            
            return ans;
        });

        return dp.GetOrCalculate((zero, one, limit));
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
