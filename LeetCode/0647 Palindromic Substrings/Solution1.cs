using JetBrains.Annotations;

namespace LeetCode._0647_Palindromic_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/941791115/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountSubstrings(string s)
    {
        var n = s.Length;

        var dp = new DynamicProgramming<int, List<int>>((startIndex, recursiveFunc) =>
        {
            return startIndex == n
                ? new List<int>()
                : recursiveFunc(startIndex + 1)
                    .Select(endOfNextPalindrome => endOfNextPalindrome + 1)
                    .Append(startIndex + 1)
                    .Where(endIndex => endIndex < n && s[startIndex] == s[endIndex])
                    .Append(startIndex)
                    .ToList();
        });

        return Enumerable.Range(0, n).Sum(i => dp.GetOrCalculate(i).Count);
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
