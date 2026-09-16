namespace LeetCode.Problems._3348_Smallest_Divisible_Digit_Product_II;

/// <summary>
/// https://leetcode.com/problems/smallest-divisible-digit-product-ii/submissions/2097407215/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution01 : ISolution
{
    public string SmallestNumber(string num, long t)
    {
        var primeFactorsMap = new Dictionary<int, int[]>
        {
            [1] = Array.Empty<int>(),
            [2] = new[] { 2 },
            [3] = new[] { 3 },
            [4] = new[] { 2, 2 },
            [5] = new[] { 5 },
            [6] = new[] { 2, 3 },
            [7] = new[] { 7 },
            [8] = new[] { 2, 2, 2 },
            [9] = new[] { 3, 3 },
        };

        var t2 = t;

        var digitPrimes = new[] { 2, 3, 5, 7 };

        foreach (var prime in digitPrimes)
        {
            while (t2 % prime == 0)
            {
                t2 /= prime;
            }
        }

        const string impossible = "-1";

        if (t2 != 1)
        {
            return impossible;
        }

        var minStrDp = new DynamicProgramming<long, string>((divisor, _) =>
        {
            var digits = new List<int>();

            for (var digit = 9; digit >= 2; digit--)
            {
                while (divisor % digit == 0)
                {
                    digits.Insert(0, digit);
                    divisor /= digit;
                }
            }

            return string.Concat(digits);
        });

        var dp = new DynamicProgramming<(long divisor, string minNumStr), string>((key, getOrCalculate) =>
        {
            var (divisor, minNumStr) = key;

            var minStr = minStrDp.GetOrCalculate(divisor);

            if (minNumStr.Length < minStr.Length)
            {
                return minStr;
            }

            if (minNumStr.Length == minStr.Length && minNumStr.CompareTo(minStr, StringComparison.InvariantCulture) <= 0)
            {
                return minStr;
            }

            var minPrefix = minNumStr[0] - '0';
            var prefix = minPrefix;

            while (true)
            {
                var nextDivisor = divisor;

                foreach (var prefixDigit in Convert.ToString(prefix).Select(digit => digit - '0'))
                {
                    foreach (var prime in primeFactorsMap[prefixDigit])
                    {
                        if (nextDivisor % prime == 0)
                        {
                            nextDivisor /= prime;
                        }
                    }
                }

                var nextMinNumStr = prefix == minPrefix ? minNumStr[1..] : "0";
                var subResult = getOrCalculate((nextDivisor, nextMinNumStr));

                var onesPrefixLength = minNumStr.Length - 1 - subResult.Length;

                if (onesPrefixLength >= 0)
                {
                    return minNumStr[0] + new string('1', onesPrefixLength) + subResult;
                }

                do
                {
                    prefix++;
                } while (Convert.ToString(prefix).Contains('0'));
            }
        });

        return dp.GetOrCalculate((t, num));
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
