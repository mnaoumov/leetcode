namespace LeetCode.Problems._3472_Longest_Palindromic_Subsequence_After_at_Most_K_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-439/problems/longest-palindromic-subsequence-after-at-most-k-operations/submissions/1559874384/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestPalindromicSubsequence(string s, int k)
    {
        var dp = new DynamicProgramming<(int startingIndex, int length, int operationsLeft), int>((key, recursiveFunc) =>
        {
            var (startingIndex, length, operationsLeft) = key;

            if (startingIndex >= s.Length)
            {
                return 0;
            }

            switch (length)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
            }

            var ans = recursiveFunc((startingIndex + 1, length - 1, operationsLeft));
            ans = Math.Max(ans, recursiveFunc((startingIndex, length - 1, operationsLeft)));
            var dist = Math.Abs(s[startingIndex] - s[startingIndex + length - 1]);
            dist = Math.Min(dist, 26 - dist);

            if (dist <= operationsLeft)
            {
                ans = Math.Max(ans, 2 + recursiveFunc((startingIndex + 1, length - 2, operationsLeft - dist)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, s.Length, k));
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
