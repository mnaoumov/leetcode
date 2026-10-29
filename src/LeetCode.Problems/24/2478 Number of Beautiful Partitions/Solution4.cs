namespace LeetCode.Problems._2478_Number_of_Beautiful_Partitions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-320/submissions/detail/846677563/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    private const int Modulo = 1000000007;

    public int BeautifulPartitions(string s, int k, int minLength)
    {
        var primeDigits = new HashSet<char>(new[] { '2', '3', '5', '7' });

        var dp = new DynamicProgramming<(int startIndex, int length, int partsLeft), int>((key, recursiveFunc) =>
        {
            var (startIndex, length, partsLeft) = key;

            if (s.Length < length + (partsLeft - 1) * minLength)
            {
                return 0;
            }

            if (partsLeft == 0 || startIndex >= s.Length)
            {
                if (partsLeft == 0 && startIndex >= s.Length)
                {
                    return 1;
                }

                return 0;
            }

            var endIndex = startIndex + length - 1;

            if (endIndex >= s.Length)
            {
                return 0;
            }

            var firstDigit = s[startIndex];
            var lastDigit = s[endIndex];

            if (!primeDigits.Contains(firstDigit))
            {
                return 0;
            }

            var result = recursiveFunc((startIndex, length + 1, partsLeft));

            if (!primeDigits.Contains(lastDigit))
            {
                result = (result + recursiveFunc((startIndex + length, minLength, partsLeft - 1))) % Modulo;
            }

            return result;
        });


        return dp.GetOrCalculate((0, minLength, k));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }

}
