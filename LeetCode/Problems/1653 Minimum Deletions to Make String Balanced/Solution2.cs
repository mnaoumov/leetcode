namespace LeetCode.Problems._1653_Minimum_Deletions_to_Make_String_Balanced;

/// <summary>
/// https://leetcode.com/submissions/detail/1338990430/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MinimumDeletions(string s)
    {
        var dp = new DynamicProgramming<(int start, int end), int>((key, recursiveFunc) =>
        {
            var (start, end) = key;

            while (start < end && s[start] == 'a')
            {
                start++;
            }

            while (end >= start && s[end] == 'b')
            {
                end--;
            }

            if (start >= end)
            {
                return 0;
            }

            return 1 + Math.Min(recursiveFunc((start + 1, end)), recursiveFunc((start, end - 1)));
        });

        return dp.GetOrCalculate((0, s.Length - 1));
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
