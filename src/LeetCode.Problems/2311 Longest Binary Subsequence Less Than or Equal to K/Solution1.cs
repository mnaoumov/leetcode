namespace LeetCode.Problems._2311_Longest_Binary_Subsequence_Less_Than_or_Equal_to_K;

/// <summary>
/// https://leetcode.com/problems/longest-binary-subsequence-less-than-or-equal-to-k/submissions/1678786688/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int LongestSubsequence(string s, int k)
    {
        var dp = new DynamicProgramming<(int index, int value, int length), int>((key, recursiveFunc) =>
        {
            var (index, value, length) = key;

            if (index == s.Length)
            {
                return length;
            }

            var ans = recursiveFunc((index + 1, value, length));

            var digit = s[index] - '0';

            var newValue = value * 2 + digit;

            if (newValue <= k)
            {
                ans = Math.Max(ans, recursiveFunc((index + 1, newValue, length + 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0));
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
