using JetBrains.Annotations;

namespace LeetCode.Problems._2746_Decremental_String_Concatenation;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-107/submissions/detail/978580167/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimizeConcatenatedLength(string[] words)
    {
        var dp = new DynamicProgramming<(int index, char firstLetter, char lastLetter), int>((key, recursiveFunc) =>
        {
            var (index, firstLetter, lastLetter) = key;

            if (index == words.Length)
            {
                return 0;
            }

            var word = words[index];

            var ans = word.Length + Math.Min(
                (lastLetter == word[0] ? -1 : 0) + recursiveFunc((index + 1, firstLetter, word[^1])),
                (firstLetter == word[^1] ? -1 : 0) + recursiveFunc((index + 1, word[0], lastLetter))
            );

            return ans;
        });

        return words[0].Length + dp.GetOrCalculate((1, words[0][0], words[0][^1]));
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
