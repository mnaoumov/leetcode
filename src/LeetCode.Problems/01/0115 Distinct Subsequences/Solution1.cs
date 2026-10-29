namespace LeetCode.Problems._0115_Distinct_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/834370368/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumDistinct(string s, string t)
    {
        var dp = new DynamicProgramming<(int sIndex, int tIndex), int>((key, calculateFunc) =>
        {
            var (sIndex, tIndex) = key;

            if (tIndex == t.Length)
            {
                return 1;
            }

            if (sIndex >= s.Length)
            {
                return 0;
            }

            var result = calculateFunc((sIndex + 1, tIndex));

            if (s[sIndex] == t[tIndex])
            {
                result += calculateFunc((sIndex + 1, tIndex + 1));
            }

            return result;
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
