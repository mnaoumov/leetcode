namespace LeetCode.Problems._2484_Count_Palindromic_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/850356449/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountPalindromes(string s)
    {
        var dp = new DynamicProgramming<(int index, string prefix), int>((key, recursiveFunc) =>
        {
            var (index, prefix) = key;

            if (prefix.Length == 5)
            {
                return 1;
            }

            if (index == s.Length)
            {
                return 0;
            }

            var result = recursiveFunc((index + 1, prefix));

            var symbol = s[index];

            if (prefix.Length < 3 || prefix.Length == 3 && symbol == prefix[1] || prefix.Length == 4 && symbol == prefix[0])
            {
                result += recursiveFunc((index + 1, prefix + symbol));
            }

            return result;
        });

        return dp.GetOrCalculate((0, ""));
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
