namespace LeetCode.Problems._0097_Interleaving_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829630222/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        var dp = new DynamicProgramming<(int index1, int index2), bool>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 == s1.Length && index2 == s2.Length)
            {
                return true;
            }

            var match1 = index1 < s1.Length && s1[index1] == s3[index1 + index2] && recursiveFunc((index1 + 1, index2));
            var match2 = index2 < s2.Length && s2[index2] == s3[index1 + index2] && recursiveFunc((index1, index2 + 1));

            return match1 || match2;
        });

        return dp.GetOrCalculate((0, 0));
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
