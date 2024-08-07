using JetBrains.Annotations;

namespace LeetCode.Problems._1653_Minimum_Deletions_to_Make_String_Balanced;

/// <summary>
/// https://leetcode.com/submissions/detail/1338995060/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MinimumDeletions(string s)
    {
        var groupCounts = new List<int> { 0 };

        foreach (var letter in s)
        {
            var expectedLetter = groupCounts.Count % 2 == 1 ? 'a' : 'b';
            if (letter == expectedLetter)
            {
                groupCounts[^1]++;
            }
            else
            {
                groupCounts.Add(1);
            }
        }

        if (groupCounts.Count % 2 == 1)
        {
            groupCounts.Add(0);
        }

        var dp = new DynamicProgramming<(int start, int end), int>((key, recursiveFunc) =>
        {
            var (start, end) = key;

            if (end - start <= 1)
            {
                return 0;
            }

            return Math.Min(
                groupCounts[start + 1] + recursiveFunc((start + 2, end)),
                groupCounts[end - 1] + recursiveFunc((start, end - 2))
            );
        });

        return dp.GetOrCalculate((0, groupCounts.Count - 1));
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
