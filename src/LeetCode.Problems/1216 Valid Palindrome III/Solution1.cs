namespace LeetCode.Problems._1216_Valid_Palindrome_III;

/// <summary>
/// https://leetcode.com/submissions/detail/954096903/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsValidPalindrome(string s, int k)
    {
        var dp = new DynamicProgramming<(int startIndex, int endIndex, int maxRemoveLetterCount), bool>((key, recursiveFunc) =>
        {
            var (startIndex, endIndex, maxRemoveLetterCount) = key;

            if (endIndex - startIndex + 1 <= maxRemoveLetterCount)
            {
                return true;
            }

            if (s[startIndex] == s[endIndex])
            {
                return recursiveFunc((startIndex + 1, endIndex - 1, maxRemoveLetterCount));
            }

            return
                maxRemoveLetterCount > 0
                && (
                    recursiveFunc((startIndex, endIndex - 1, maxRemoveLetterCount - 1))
                    || recursiveFunc((startIndex + 1, endIndex, maxRemoveLetterCount - 1))
                );
        });

        return dp.GetOrCalculate((0, s.Length - 1, k));
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
