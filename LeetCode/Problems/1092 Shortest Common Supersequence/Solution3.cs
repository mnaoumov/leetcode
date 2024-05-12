using JetBrains.Annotations;

namespace LeetCode.Problems._1092_Shortest_Common_Supersequence;

/// <summary>
/// https://leetcode.com/submissions/detail/954074081/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), (IEnumerable<char> letters, int count)>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 == str1.Length)
            {
                return (str2[index2..], str2.Length - index2);
            }

            if (index2 == str2.Length)
            {
                return (str1[index1..], str1.Length - index1);
            }

            var letter1 = str1[index1];
            var letter2 = str2[index2];

            if (letter1 == letter2)
            {
                var (letters, count) = recursiveFunc((index1 + 1, index2 + 1));
                return (letters.Prepend(letter1), count + 1);
            }

            var (letters1, count1) = recursiveFunc((index1 + 1, index2));
            var (letters2, count2) = recursiveFunc((index1, index2 + 1));

            return count1 <= count2 ? (letters1.Prepend(letter1), count1 + 1) : (letters2.Prepend(letter2), count2 + 1);
        });

        return string.Concat(dp.GetOrCalculate((0, 0)).letters);
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
