namespace LeetCode.Problems._3767_Maximize_Points_After_Choosing_K_Tasks;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-171/problems/maximize-points-after-choosing-k-tasks/submissions/1848446059/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaxPoints(int[] technique1, int[] technique2, int k)
    {
        var n = technique1.Length;

        var dp = new DynamicProgramming<(int index, int minTechnique1Tasks), long>((key, getOrCalculate) =>
        {
            var (index, minTechnique1Tasks) = key;

            if (index == n)
            {
                return 0;
            }

            var ans = technique1[index] + getOrCalculate((index + 1, minTechnique1Tasks - 1));

            if (n > index + minTechnique1Tasks)
            {
                ans = Math.Max(ans, technique2[index] + getOrCalculate((index + 1, minTechnique1Tasks)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, k));
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
