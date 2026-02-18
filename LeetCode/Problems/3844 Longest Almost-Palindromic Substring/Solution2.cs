namespace LeetCode.Problems._3844_Longest_Almost_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-489/problems/longest-almost-palindromic-substring/submissions/1919600037/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
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

            return
                shouldRemoveLetter && getOrCalculate((startIndex + 1, endIndex, false))
                    || shouldRemoveLetter && getOrCalculate((startIndex, endIndex - 1, false))
                    || s[startIndex] == s[endIndex] && (endIndex - startIndex <= 1 || getOrCalculate((startIndex + 1, endIndex - 1, shouldRemoveLetter)));
        });

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                if (dp.GetOrCalculate((i, j, true)))
                {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }

        return ans;
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
