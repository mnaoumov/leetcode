namespace LeetCode.Problems._0139_Word_Break;

/// <summary>
/// https://leetcode.com/problems/word-break/submissions/841077333/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var prefixesSet = new HashSet<string>();
        var wordsSet = wordDict.ToHashSet();

        foreach (var word in wordDict)
        {
            for (var i = 1; i <= word.Length; i++)
            {
                prefixesSet.Add(word[..i]);
            }
        }

        var dp = new DynamicProgramming<(int index, string prefix), bool>((key, recursiveFunc) =>
        {
            var (index, prefix) = key;

            if (index == s.Length)
            {
                return prefix == "";
            }

            var nextPrefix = prefix + s[index];

            if (!prefixesSet.Contains(nextPrefix))
            {
                return false;
            }

            return recursiveFunc((index + 1, nextPrefix)) || wordsSet.Contains(nextPrefix) && recursiveFunc((index + 1, ""));
        });

        return dp.GetOrCalculate((0, ""));
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
