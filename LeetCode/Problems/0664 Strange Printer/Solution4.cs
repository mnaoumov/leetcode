using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0664_Strange_Printer;

/// <summary>
/// https://leetcode.com/submissions/detail/1058291625/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public int StrangePrinter(string s)
    {
        var dp = new DynamicProgramming<string, int>((str, recursiveFunc) =>
        {
            if (str == "")
            {
                return 0;
            }

            var letter = str[0];
            var n = str.Length;

            var indices = Enumerable.Range(0, n).Where(i => str[i] == letter).ToArray();

            var ans = int.MaxValue;

            for (var i = 0; i < indices.Length; i++)
            {
                var ans2 = 1;
                for (var j = 0; j < i; j++)
                {
                    ans2 += recursiveFunc(str[(indices[j] + 1)..indices[j + 1]]);
                }

                ans2 += recursiveFunc(str[(indices[i] + 1)..]);

                ans = Math.Min(ans, ans2);
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
