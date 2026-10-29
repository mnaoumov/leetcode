namespace LeetCode.Problems._0712_Minimum_ASCII_Delete_Sum_for_Two_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/940320418/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        var dp = new DynamicProgramming<(int s1Index, int s2Index), int>((key, recursiveFunc) =>
        {
            var (s1Index, s2Index) = key;

            if (s1Index < s1.Length && s2Index < s2.Length && s1[s1Index] == s2[s2Index])
            {
                return recursiveFunc((s1Index + 1, s2Index + 1));
            }

            var result = int.MaxValue;

            if (s1Index < s1.Length)
            {
                result = Math.Min(result, s1[s1Index] + recursiveFunc((s1Index + 1, s2Index)));
            }

            if (s2Index < s2.Length)
            {
                result = Math.Min(result, s2[s2Index] + recursiveFunc((s1Index, s2Index + 1)));
            }

            return result == int.MaxValue ? 0 : result;
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
