namespace LeetCode.Problems._1463_Cherry_Pickup_II;

/// <summary>
/// https://leetcode.com/submissions/detail/954167113/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CherryPickup(int[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var dColumns = new[] { -1, 0, 1 };

        var dp = new DynamicProgramming<(int row, int column1, int column2), int>((key, recursiveFunc) =>
        {
            var (row, column1, column2) = key;

            if (row == rows || column1 < 0 || column1 == cols || column2 < 0 || column2 == cols)
            {
                return 0;
            }

            var ans = grid[row][column1];

            if (column1 != column2)
            {
                ans += grid[row][column2];
            }

            var next = dColumns.SelectMany(_ => dColumns, (dColumn1, dColumn2) =>
                    recursiveFunc((row + 1, column1 + dColumn1, column2 + dColumn2)))
                .Prepend(0).Max();

            return ans + next;
        });

        return dp.GetOrCalculate((0, 0, cols - 1));
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
