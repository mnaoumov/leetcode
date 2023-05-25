using JetBrains.Annotations;

namespace LeetCode._0837_New_21_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/956818881/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public double New21Game(int n, int k, int maxPts)
    {
        var dp = new DynamicProgramming<int, double>((points, recursiveFunc) =>
        {
            if (points > n)
            {
                return 0;
            }

            if (points >= k)
            {
                return 1;
            }

            var ans = 0.0;

            for (var i = 1; i <= Math.Min(maxPts, k - 1 - points); i++)
            {
                ans += 1.0 / maxPts * recursiveFunc(points + i);
            }

            var min = Math.Max(k - points, 1);
            var max = Math.Min(n - points, maxPts);

            if (min <= max)
            {
                ans += 1.0 * (max - min + 1) / maxPts;
            }

            return ans;
        });

        return dp.GetOrCalculate(0);
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
