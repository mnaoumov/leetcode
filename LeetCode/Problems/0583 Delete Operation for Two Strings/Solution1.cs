using JetBrains.Annotations;

namespace LeetCode.Problems._0583_Delete_Operation_for_Two_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/941806800/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDistance(string word1, string word2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 == word1.Length || index2 == word2.Length)
            {
                return Math.Max(word1.Length - index1, word2.Length - index2);
            }

            if (word1[index1] == word2[index2])
            {
                return recursiveFunc((index1 + 1, index2 + 1));
            }

            return 1 + Math.Min(recursiveFunc((index1 + 1, index2)), recursiveFunc((index1, index2 + 1)));
        });

        return dp.GetOrCalculate((0, 0));
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
