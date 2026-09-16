namespace LeetCode.Problems._3348_Smallest_Divisible_Digit_Product_II;

/// <summary>
/// https://leetcode.com/problems/smallest-divisible-digit-product-ii/submissions/2097470154/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution09 : ISolution
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

        var dp = new DynamicProgramming<(long divisor, string minNumStr, bool isStart), string>((key, getOrCalculate) =>
        {
            var (divisor, minNumStr, isStart) = key;

            if (divisor == 1)
            {
                return NextProperNumber(minNumStr);
            }

            if (minNumStr == "")
            {
                return impossible;
            }

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
            var prefix = Math.Max(minPrefix, 1);

            while (true)
            {
                var nextDivisor = divisor;
                var prefixStr = Convert.ToString(prefix);

                foreach (var prefixDigit in prefixStr.Select(digit => digit - '0'))
                {
                    foreach (var prime in primeFactorsMap[prefixDigit])
                    {
                        if (nextDivisor % prime == 0)
                        {
                            nextDivisor /= prime;
                        }
                    }
                }

                string nextMinNumStr;

                if (minNumStr.Length == 1)
                {
                    nextMinNumStr = "";
                }
                else if (prefix == minPrefix)
                {
                    nextMinNumStr = minNumStr[1..];
                }
                else
                {
                    nextMinNumStr = "1";
                }

                var subResult = getOrCalculate((nextDivisor, nextMinNumStr, false));

                if (subResult != impossible)
                {
                    var onesPrefixLength = minNumStr.Length - 1 - subResult.Length;

                    if (onesPrefixLength >= 0)
                    {
                        return prefixStr + new string('1', onesPrefixLength) + subResult;
                    }
                }

                var prefixLength = prefixStr.Length;

                prefixStr = NextProperNumber(Convert.ToString(prefix + 1));
                prefix = Convert.ToInt32(prefixStr);

                if (!isStart && prefixStr.Length != prefixLength)
                {
                    return impossible;
                }
            }
        });

        var minStrForT = minStrDp.GetOrCalculate(t);

        if (num.Length >= minStrForT.Length + 1)
        {
            num = NextProperNumber(num);
            var prefix = num[..^(minStrForT.Length + 1)];

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var digitChar in prefix)
            {
                var digit = digitChar - '0';

                foreach (var prime in primeFactorsMap[digit])
                {
                    if (t % prime == 0)
                    {
                        t /= prime;
                    }
                }
            }

            return prefix + dp.GetOrCalculate((t, num[^(minStrForT.Length + 1)..], false));
        }

        return dp.GetOrCalculate((t, num, true));
    }

    private static string NextProperNumber(string numStr)
    {
        var index = numStr.IndexOf('0');

        if (index == -1)
        {
            return numStr;
        }

        return numStr[..index] + new string('1', numStr.Length - index);
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
