namespace LeetCode.Problems._1937_Maximum_Number_of_Points_with_Cost;

/// <summary>
/// https://leetcode.com/submissions/detail/1358459323/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaxPoints(int[][] points)
    {
        var m = points.Length;
        var n = points[0].Length;

        var dp = new DynamicProgramming<(int row, int previousColumn), long>((key, recursiveFunc) =>
        {
            var (row, previousColumn) = key;

            if (row == m)
            {
                return 0;
            }

            var ans = long.MinValue;

            for (var column = 0; column < n; column++)
            {
                ans = Math.Max(ans,
                    points[row][column] + recursiveFunc((row + 1, column)) -
                    (row == 0 ? 0 : Math.Abs(column - previousColumn)));
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
