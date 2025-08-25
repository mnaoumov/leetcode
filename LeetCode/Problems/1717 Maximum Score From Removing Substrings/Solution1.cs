namespace LeetCode.Problems._1717_Maximum_Score_From_Removing_Substrings;

/// <summary>
/// https://leetcode.com/problems/maximum-score-from-removing-substrings/submissions/1707857163/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaximumGain(string s, int x, int y)
    {
        var dp = new DynamicProgramming<string, int>((str, recursiveFunc) =>
        {
            var ans = 0;
            for (var i = 0; i < str.Length - 1; i++)
            {
                var substr = str[i..(i + 2)];
                var rest = str.Remove(i, 2);
                ans = substr switch
                {
                    "ab" => Math.Max(ans, x + recursiveFunc(rest)),
                    "ba" => Math.Max(ans, y + recursiveFunc(rest)),
                    _ => ans
                };
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
