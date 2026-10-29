namespace LeetCode.Problems._0664_Strange_Printer;

/// <summary>
/// https://leetcode.com/submissions/detail/1012211570/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int StrangePrinter(string s)
    {
        var dp = new DynamicProgramming<string, int>((str, recursiveFunc) =>
        {
            if (str == "")
            {
                return 0;
            }

            var lastLetter = s[0];
            var sequenceCount = 1;
            var ans = int.MaxValue;

            for (var i = 1; i <= s.Length; i++)
            {
                if (i < str.Length && str[i] == lastLetter)
                {
                    sequenceCount++;
                }
                else
                {
                    var t = str[..(i - sequenceCount)] + str[i..];
                    ans = Math.Min(ans, 1 + recursiveFunc(t));

                    if (i == str.Length)
                    {
                        break;
                    }

                    lastLetter = str[i];
                    sequenceCount = 1;
                }
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
