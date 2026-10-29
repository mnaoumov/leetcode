using System.Globalization;

namespace LeetCode.Problems._3753_Total_Waviness_of_Numbers_in_Range_II;

/// <summary>
/// https://leetcode.com/problems/total-waviness-of-numbers-in-range-ii/submissions/2023716982/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public long TotalWaviness(long num1, long num2)
    {
        const int unset = -1;
        var dp = new DynamicProgramming<(long max, int length, int previousDigit, int previousDigit2), long>((key, getOrCalculate) =>
        {
            var (max, length, previousDigit, previousDigit2) = key;

            var ans = 0L;

            if (length == unset)
            {
                var maxLength = max.ToString(CultureInfo.InvariantCulture).Length;
                var powerOfTen = 1000L;

                for (var i = 3; i < maxLength; i++)
                {
                    ans += getOrCalculate((powerOfTen - 1, i, unset, unset));
                    powerOfTen *= 10;
                }

                ans += getOrCalculate((max, maxLength, unset, unset));
                return ans;
            }

            var maxPowerOfTen = 1L;

            for (var i = 0; i < length - 1; i++)
            {
                maxPowerOfTen *= 10;
            }

            if (previousDigit == unset)
            {
                for (var prefix = 10; prefix <= 99; prefix++)
                {
                    previousDigit = prefix % 10;
                    previousDigit2 = prefix / 10;

                    var nextMax = Math.Min(maxPowerOfTen / 10 - 1, max - prefix * maxPowerOfTen / 10);

                    if (nextMax < 0)
                    {
                        break;
                    }

                    ans += getOrCalculate((nextMax, length - 2, previousDigit, previousDigit2));
                }
            }
            else
            {
                for (var digit = 0; digit <= 9; digit++)
                {
                    var nextMax = Math.Min(maxPowerOfTen - 1, max - digit * maxPowerOfTen);

                    if (nextMax < 0)
                    {
                        break;
                    }

                    if (nextMax > 0)
                    {
                        ans += getOrCalculate((nextMax, length - 1, digit, previousDigit));
                    }

                    if (digit < previousDigit && previousDigit2 < previousDigit)
                    {
                        ans += nextMax + 1;
                    }

                    if (digit > previousDigit && previousDigit2 > previousDigit)
                    {
                        ans += nextMax + 1;
                    }
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((num2, unset, unset, unset)) - dp.GetOrCalculate((num1 - 1, unset, unset, unset));
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
}
