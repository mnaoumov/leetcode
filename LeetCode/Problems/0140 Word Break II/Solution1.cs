namespace LeetCode.Problems._0140_Word_Break_II;

/// <summary>
/// https://leetcode.com/problems/word-break-ii/submissions/841550736/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        var wordsSet = wordDict.ToHashSet();
        var prefixesSet = new HashSet<string>();

        foreach (var word in wordDict)
        {
            for (var i = 1; i <= word.Length; i++)
            {
                prefixesSet.Add(word[..i]);
            }
        }

        var dp = new DynamicProgramming<(int index, string prefix), IEnumerable<string>>((key, recursiveFunc) =>
        {
            return Enumerate();

            IEnumerable<string> Enumerate()
            {
                var (index, prefix) = key;

                if (index == s.Length)
                {
                    if (wordsSet.Contains(prefix))
                    {
                        yield return prefix;
                    }
                    yield break;
                }

                var nextPrefix = prefix + s[index];

                if (!prefixesSet.Contains(nextPrefix))
                {
                    yield break;
                }

                foreach (var str in recursiveFunc((index + 1, nextPrefix)))
                {
                    yield return str;
                }

                if (wordsSet.Contains(nextPrefix))
                {
                    foreach (var str in recursiveFunc((index + 1, "")))
                    {
                        yield return $"{nextPrefix} {str}";
                    }
                }
            }
        });

        return dp.GetOrCalculate((0, "")).ToArray();
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
