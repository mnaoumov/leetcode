using JetBrains.Annotations;

namespace LeetCode._1312_Minimum_Insertion_Steps_to_Make_a_String_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/937668947/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinInsertions(string s)
    {
        var dp = new DynamicProgramming<(int start, int end), int>((key, recursiveFunc) =>
        {
            var (start, end) = key;

            return end <= start
                ? 0
                : s[start] == s[end]
                    ? recursiveFunc((start + 1, end - 1))
                    : 1 + Math.Min(recursiveFunc((start + 1, end)), recursiveFunc((start, end - 1)));
        });

        return dp.GetOrCalculate((0, s.Length - 1));
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
