namespace LeetCode.Problems._3651_Minimum_Cost_Path_with_Teleportations;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-path-with-teleportations/submissions/1899203495/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinCost(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var entries = new SortedSet<(int cost, int row, int column)>();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                entries.Add((grid[row][column], row, column));
            }
        }

        var dp = new DynamicProgramming<(int row, int column, int teleportsLeft), int>((key, getOrCalculate) =>
        {
            var (row, column, teleportsLeft) = key;

            if (row == m - 1 && column == n - 1)
            {
                return 0;
            }

            var ans = int.MaxValue;

            if (row < m - 1)
            {
                ans = Math.Min(ans, grid[row + 1][column] + getOrCalculate((row + 1, column, teleportsLeft)));
            }

            if (column < n - 1)
            {
                ans = Math.Min(ans, grid[row][column + 1] + getOrCalculate((row, column + 1, teleportsLeft)));
            }

            if (teleportsLeft <= 0)
            {
                return ans;
            }

            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var entry in entries.GetViewBetween((0, 0, 0), (grid[row][column], m - 1, n - 1)))
            {
                if (entry.row == row && entry.column == column)
                {
                    continue;
                }

                ans = Math.Min(ans, getOrCalculate((entry.row, entry.column, teleportsLeft - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, k));
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
