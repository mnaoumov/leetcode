namespace LeetCode.Problems._1682_Longest_Palindromic_Subsequence_II;

/// <summary>
/// https://leetcode.com/submissions/detail/951110382/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestPalindromeSubseq(string s)
    {
        var dp = new DynamicProgramming<(int startIndex, int endIndex, char previousLetter), int>((key, recursiveFunc) =>
        {
            var (startIndex, endIndex, previousLetter) = key;

            if (startIndex >= endIndex)
            {
                return 0;
            }

            var ans = recursiveFunc((startIndex + 1, endIndex, previousLetter));

            var startIndices = new Dictionary<char, int>();
            var endIndices = new Dictionary<char, int>();

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (startIndices.ContainsKey(s[i]))
                {
                    continue;
                }

                startIndices[s[i]] = i;
            }

            for (var i = endIndex; i >= startIndex; i--)
            {
                if (endIndices.ContainsKey(s[i]))
                {
                    continue;
                }

                endIndices[s[i]] = i;
            }

            foreach (var (letter, startIndex2) in startIndices)
            {
                if (letter == previousLetter)
                {
                    continue;
                }

                var endIndex2 = endIndices[letter];

                if (startIndex2 < endIndex2)
                {
                    ans = Math.Max(ans, 2 + recursiveFunc((startIndex2 + 1, endIndex2 - 1, s[startIndex2])));
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, s.Length - 1, default));
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
