namespace LeetCode.Problems._3332_Maximum_Points_Tourist_Can_Earn;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-142/submissions/detail/1434345357/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxScore(int n, int k, int[][] stayScore, int[][] travelScore)
    {
        var dp = new DynamicProgramming<(int day, int currentCity), int>((key, recursiveFunc) =>
        {
            var (day, currentCity) = key;

            if (day == k)
            {
                return 0;
            }

            var ans = 0;

            for (var nextCity = 0; nextCity < n; nextCity++)
            {
                var score = nextCity == currentCity ? stayScore[day][nextCity] : travelScore[currentCity][nextCity];
                ans = Math.Max(ans, score + recursiveFunc((day + 1, nextCity)));
            }

            return ans;
        });

        return Enumerable.Range(0, n).Select(city => dp.GetOrCalculate((0, city))).Max();
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
