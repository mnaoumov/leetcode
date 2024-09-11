namespace LeetCode.Problems._2472_Maximum_Number_of_Non_overlapping_Palindrome_Substrings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-319/submissions/detail/842372672/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxPalindromes(string s, int k)
    {
        var isPalindromeDp = new DynamicProgramming<(int startIndex, int endIndex), bool>((key, _) =>
        {
            var (startIndex, endIndex) = key;

            while (startIndex < endIndex)
            {
                if (s[startIndex] != s[endIndex])
                {
                    return false;
                }

                startIndex++;
                endIndex--;
            }

            return true;
        });

        var dp = new DynamicProgramming<(int startIndex, int endIndex), int>((key, recursiveFunc) =>
        {
            var (startIndex, endIndex) = key;

            if (endIndex >= s.Length)
            {
                return 0;
            }

            var result = 0;

            if (endIndex - startIndex + 1 >= k && isPalindromeDp.GetOrCalculate((startIndex, endIndex)))
            {
                result = 1 + recursiveFunc((endIndex + 1, endIndex + 1));
            }

            result = Math.Max(result, recursiveFunc((startIndex, endIndex + 1)));
            result = Math.Max(result, recursiveFunc((startIndex + 1, startIndex + 1)));

            return result;
        });

        return dp.GetOrCalculate((0, 0));
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
