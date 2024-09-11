namespace LeetCode.Problems._1143_Longest_Common_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/859977937/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;
            if (index1 < 0 || index2 < 0)
            {
                return 0;
            }

            return text1[index1] == text2[index2]
                ? 1 + recursiveFunc((index1 - 1, index2 - 1))
                : Math.Max(recursiveFunc((index1 - 1, index2)), recursiveFunc((index1, index2 - 1)));
        });

        return dp.GetOrCalculate((text1.Length - 1, text2.Length - 1));
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
