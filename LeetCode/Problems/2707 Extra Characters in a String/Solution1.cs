using JetBrains.Annotations;

namespace LeetCode.Problems._2707_Extra_Characters_in_a_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-105/submissions/detail/958325649/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinExtraChar(string s, string[] dictionary)
    {
        var dp = new DynamicProgramming<int, int>((startIndex, recursiveFunc) =>
        {
            if (startIndex >= s.Length)
            {
                return 0;
            }

            var prefixWords = dictionary.Where(word => s[startIndex..].StartsWith(word));
            return prefixWords.Select(prefixWord => recursiveFunc(startIndex + prefixWord.Length)).Prepend(1 + recursiveFunc(startIndex + 1)).Min();
        });

        return dp.GetOrCalculate(0);
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
