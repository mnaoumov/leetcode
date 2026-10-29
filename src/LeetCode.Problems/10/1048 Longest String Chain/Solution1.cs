using System.Text;

namespace LeetCode.Problems._1048_Longest_String_Chain;

/// <summary>
/// https://leetcode.com/submissions/detail/940379544/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestStrChain(string[] words)
    {
        var set = words.ToHashSet();

        var dp = new DynamicProgramming<string, int>((word, recursiveFunc) =>
        {
            var sb = new StringBuilder(word);

            var result = 1;

            for (var i = 0; i < sb.Length; i++)
            {
                var letter = sb[i];
                sb.Remove(i, 1);
                var nextWord = sb.ToString();

                if (set.Contains(nextWord))
                {
                    result = Math.Max(result, 1 + recursiveFunc(nextWord));
                }

                sb.Insert(i, letter);
            }

            return result;
        });

        return words.Max(word => dp.GetOrCalculate(word));
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
