namespace LeetCode.Problems._2801_Count_Stepping_Numbers_in_Range;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-356/submissions/detail/1007388720/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountSteppingNumbers(string low, string high)
    {
        const int noDigit = -1;

        var dp = new DynamicProgramming<(string low2, string high2, int previousDigit), ModNumber>((key, recursiveFunc) =>
        {
            var (low2, high2, previousDigit) = key;

            if (low2 == "")
            {
                return 1;
            }

            var lowDigit = low2[0] - '0';
            var highDigit = high2[0] - '0';

            ModNumber ans = 0;

            for (var firstDigit = lowDigit; firstDigit <= highDigit; firstDigit++)
            {
                if (previousDigit != noDigit && Math.Abs(previousDigit - firstDigit) != 1)
                {
                    continue;
                }

                var nextLow = firstDigit == lowDigit ? low2[1..] : new string('0', low2.Length - 1);
                var nextHigh = firstDigit == highDigit ? high2[1..] : new string('9', low2.Length - 1);
                var nextPreviousDigit = previousDigit != noDigit || firstDigit > 0 ? firstDigit : noDigit;
                ans += recursiveFunc((nextLow, nextHigh, nextPreviousDigit));
            }

            return ans;
        });

        var paddedLow = low.PadLeft(high.Length, '0');
        return dp.GetOrCalculate((paddedLow, high, noDigit));
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

        private ModNumber(int value) => _value = value % Modulo;
        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public override string ToString() => _value.ToString();
    }
}
