using JetBrains.Annotations;

namespace LeetCode.Problems._0392_Is_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/853984635/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public bool IsSubsequence(string s, string t)
    {
        var dp = new DynamicProgramming<(int sIndex, int tIndex), int>((key, recursiveFunc) =>
        {
            var (sIndex, tIndex) = key;

            if (sIndex < 0 || tIndex < 0)
            {
                return 0;
            }

            if (s[sIndex] == t[tIndex])
            {
                return recursiveFunc((sIndex - 1, tIndex - 1)) + 1;
            }

            return Math.Max(recursiveFunc((sIndex - 1, tIndex)), recursiveFunc((sIndex, tIndex - 1)));
        });

        return dp.GetOrCalculate((s.Length - 1, t.Length - 1)) == s.Length;
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
