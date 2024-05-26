using JetBrains.Annotations;

namespace LeetCode.Problems._0552_Student_Attendance_Record_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1267949955/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CheckRecord(int n)
    {
        const int maxAllowedLateCount = 2;

        var dp = new DynamicProgramming<(int length, int allowedAbsenceCount, int allowedLateCount), ModNumber>((key, recursiveFunc) =>
        {
            var (length, allowedAbsenceCount, allowedLateCount) = key;

            if (length == 0)
            {
                return 1;
            }

            var ans = recursiveFunc((length - 1, allowedAbsenceCount, maxAllowedLateCount));

            if (allowedAbsenceCount > 0)
            {
                ans += recursiveFunc((length - 1, allowedAbsenceCount - 1, maxAllowedLateCount));
            }

            if (allowedLateCount > 0)
            {
                ans += recursiveFunc((length - 1, allowedAbsenceCount, allowedLateCount - 1));
            }

            return ans;
        });

        return dp.GetOrCalculate((n, 1, maxAllowedLateCount));
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
