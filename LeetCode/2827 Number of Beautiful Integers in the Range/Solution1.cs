using JetBrains.Annotations;

namespace LeetCode._2827_Number_of_Beautiful_Integers_in_the_Range;

/// <summary>
/// https://leetcode.com/submissions/detail/1025917253/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfBeautifulIntegers(int low, int high, int k)
    {
        var dp = new DynamicProgramming<(int max, int evenOddBalance, int remainder, bool allowLeadingZero), int>(
            (key, recursiveFunc) =>
            {
                var (max, evenOddBalance, remainder, allowLeadingZero) = key;

                if (max == -1)
                {
                    return evenOddBalance == 0 && allowLeadingZero && remainder == 0 ? 1 : 0;
                }

                var firstDigit = max;
                var withoutFirstDigit = 0;
                var powerOfTen = 1;

                while (firstDigit >= 10)
                {
                    var lastDigit = firstDigit % 10;
                    withoutFirstDigit = 10 * withoutFirstDigit + lastDigit;
                    firstDigit /= 10;
                    powerOfTen *= 10;
                }

                var ans = 0;

                for (var digit = 0; digit <= firstDigit; digit++)
                {
                    ans += recursiveFunc((
                            max: max < 10 ? -1 : digit == firstDigit ? withoutFirstDigit : powerOfTen - 1,
                            evenOddBalance: evenOddBalance +
                                            (digit == 0 && !allowLeadingZero ? 0 : digit % 2 == 0 ? 1 : -1),
                            remainder: (k + remainder - digit * powerOfTen % k) % k,
                            allowLeadingZero: allowLeadingZero || digit != 0)
                    );
                }

                return ans;
            });

        return dp.GetOrCalculate((high, 0, 0, false)) - dp.GetOrCalculate((low - 1, 0, 0, false));
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
