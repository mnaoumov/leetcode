namespace LeetCode.Problems._3742_Maximum_Path_Score_in_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-475/problems/maximum-path-score-in-a-grid/submissions/1824645943/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int impossible = -1;

        var dp = new DynamicProgramming<(int row, int column, int costLeft), int>((key, getOrCalculate) =>
        {
            var (row, column, costLeft) = key;

            var value = grid[row][column];
            var newCostLeft = costLeft - (value == 0 ? 0 : 1);

            if (newCostLeft < 0)
            {
                return impossible;
            }

            if (row == m - 1 && column == n - 1)
            {
                return value;
            }

            var ans = impossible;

            if (row < m - 1)
            {
                var next = getOrCalculate((row + 1, column, newCostLeft));

                if (next != impossible)
                {
                    ans = Math.Max(ans, value + next);
                }
            }

            if (column < n - 1)
            {
                var next = getOrCalculate((row, column + 1, newCostLeft));

                if (next != impossible)
                {
                    ans = Math.Max(ans, value + next);
                }
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
