namespace LeetCode.Problems._3844_Longest_Almost_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-489/problems/longest-almost-palindromic-substring/submissions/1919608959/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int AlmostPalindromic(string s)
    {
        var n = s.Length;

        var dp = new DynamicProgramming<(int startIndex, int endIndex, bool shouldRemoveLetter), bool>((key, getOrCalculate) =>
        {
            var (startIndex, endIndex, shouldRemoveLetter) = key;

            if (startIndex == endIndex)
            {
                return true;
            }

            if (s[startIndex] == s[endIndex])
            {
                return endIndex - startIndex == 1 || getOrCalculate((startIndex + 1, endIndex - 1, shouldRemoveLetter));
            }

            if (!shouldRemoveLetter)
            {
                return false;
            }

            return getOrCalculate((startIndex + 1, endIndex, false)) || getOrCalculate((startIndex, endIndex - 1, false));
        });

        for (var length = n; length >= 3; length--)
        {
            for (var i = 0; i <= n - length; i++)
            {
                if (dp.GetOrCalculate((i, i + length - 1, true)))
                {
                    return length;
                }
            }
        }

        return 2;
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
