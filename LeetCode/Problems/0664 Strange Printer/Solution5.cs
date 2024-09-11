using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0664_Strange_Printer;

/// <summary>
/// https://leetcode.com/submissions/detail/1063090210/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public int StrangePrinter(string s)
    {
        var dp = new DynamicProgramming<string, int>((str, recursiveFunc) =>
        {
            if (str == "")
            {
                return 0;
            }

            var ans = int.MaxValue;

            var groupStartIndex = 0;

            for (var i = 0; i < str.Length; i++)
            {
                if (i < str.Length - 1 && str[i] == str[i + 1])
                {
                    continue;
                }

                ans = Math.Min(ans, 1 + recursiveFunc(str[..groupStartIndex] + str[(i + 1)..]));
                groupStartIndex = i + 1;
            }

            return ans;
        });

        return dp.GetOrCalculate(s);
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
