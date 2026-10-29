

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2484_Count_Palindromic_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/850361700/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int CountPalindromes(string s)
    {
        const int modulo = 1000000007;

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

            var result = 0;

            for (var nextIndex = index; nextIndex < s.Length; nextIndex++)
            {
                var symbol = s[nextIndex];


                if (prefix.Length == 3 && symbol != prefix[1])
                {
                    continue;
                }

                if (prefix.Length == 4 && symbol != prefix[0])
                {
                    continue;
                }

                result = (result + recursiveFunc((nextIndex + 1, prefix + symbol))) % modulo;
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
