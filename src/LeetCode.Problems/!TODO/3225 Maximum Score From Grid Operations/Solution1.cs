namespace LeetCode.Problems._3225_Maximum_Score_From_Grid_Operations;

/// <summary>
/// https://leetcode.com/problems/maximum-score-from-grid-operations/submissions/1990698090/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaximumScore(int[][] grid)
    {
        var n = grid.Length;

#pragma warning disable CA1814
        var prefixSums = new long[n + 1, n];
#pragma warning restore CA1814

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                prefixSums[i + 1, j] = prefixSums[i, j] + grid[i][j];
            }
        }

        var dp = new DynamicProgramming<(int column, int previousBlackRowsCount, int beforePreviousBlackRowsCount), long>((key, getOrCalculate) =>
        {
            var (column, previousBlackRowsCount, beforePreviousBlackRowsCount) = key;

            if (column == n + 1)
            {
                return 0;
            }

            var maxRowCount = column == n ? 0 : n;

            var ans = 0L;

            for (var blackRowsCount = 0; blackRowsCount <= maxRowCount; blackRowsCount++)
            {
                var sidesMaxRowCount = Math.Max(beforePreviousBlackRowsCount, blackRowsCount);

                var previousColumnValue = 0L;

                if (column > 0 && sidesMaxRowCount > previousBlackRowsCount)
                {
                    previousColumnValue = prefixSums[sidesMaxRowCount, column - 1] -
                                          prefixSums[previousBlackRowsCount, column - 1];
                }

                ans = Math.Max(ans,
                    previousColumnValue + getOrCalculate((column + 1, blackRowsCount, previousBlackRowsCount)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
