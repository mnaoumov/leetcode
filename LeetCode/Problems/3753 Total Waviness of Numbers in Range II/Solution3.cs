using System.Globalization;

namespace LeetCode.Problems._3753_Total_Waviness_of_Numbers_in_Range_II;

/// <summary>
/// https://leetcode.com/problems/total-waviness-of-numbers-in-range-ii/submissions/2023711675/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public long TotalWaviness(long num1, long num2)
    {
        const int unset = -1;
        var dp = new DynamicProgramming<(long max, int maxLength, int previousDigit, int previousDigit2), long>((key, getOrCalculate) =>
        {
            var (max, maxLength, previousDigit, previousDigit2) = key;

            if (previousDigit == unset && max < 100)
            {
                return 0;
            }

            var maxPowerOfTen = 1L;
            var length = 1;

            var ans = 0L;

            if (previousDigit == unset)
            {
                while (10 * maxPowerOfTen <= max)
                {
                    ans += getOrCalculate((10 * maxPowerOfTen - 1, length, unset, unset));
                    maxPowerOfTen *= 10;
                    length++;
                }
            }
            else
            {
                for (var i = 0; i < maxLength - 1; i++)
                {
                    maxPowerOfTen *= 10;
                }
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

        return dp.GetOrCalculate((num2, num2.ToString(CultureInfo.InvariantCulture).Length, unset, unset)) - dp.GetOrCalculate((num1 - 1, (num1 - 1).ToString(CultureInfo.InvariantCulture).Length, unset, unset));
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
