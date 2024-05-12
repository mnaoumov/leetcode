using JetBrains.Annotations;

namespace LeetCode.Problems._0568_Maximum_Vacation_Days;

/// <summary>
/// https://leetcode.com/submissions/detail/1073017177/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MaxVacationDays(int[][] flights, int[][] days)
    {
        var k = days.Length;
        var n = flights.Length;

        var dp = new DynamicProgramming<(int city, int weekNumber), int>((key, recursiveFunc) =>
        {
            var (city, weekNumber) = key;

            if (weekNumber == k)
            {
                return 0;
            }

            var ans = 0;

            for (var nextCity = 0; nextCity < n; nextCity++)
            {
                if (city == nextCity || flights[city][nextCity] == 1)
                {
                    ans = Math.Max(ans, days[nextCity][weekNumber] + recursiveFunc((nextCity, weekNumber + 1)));
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
