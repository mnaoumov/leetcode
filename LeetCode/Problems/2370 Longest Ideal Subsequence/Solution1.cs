using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2370_Longest_Ideal_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/1241850422/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.StackOverflow)]
public class Solution1 : ISolution
{
    public int LongestIdealString(string s, int k)
    {
        const char noLetter = '\0';
        
        var dp = new DynamicProgramming<(int index, char previousLetter), int>((key, recursiveFunc) =>
        {
            var (index, previousLetter) = key;

            if (index == s.Length)
            {
                return 0;
            }

            var ans = recursiveFunc((index + 1, previousLetter));

            var letter = s[index];

            if (previousLetter == noLetter || Math.Abs(previousLetter - letter) <= k)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, letter)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noLetter));
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
