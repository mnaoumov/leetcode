using JetBrains.Annotations;

namespace LeetCode.Problems._2684_Maximum_Number_of_Moves_in_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-345/submissions/detail/949936222/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxMoves(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var dRows = new[] { -1, 0, 1 };

        var dp = new DynamicProgramming<(int row, int column), int>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            if (column == n - 1)
            {
                return 0;
            }

            return dRows.Select(dRow => row + dRow)
                .Where(nextRow => nextRow >= 0 && nextRow < m && grid[nextRow][column + 1] > grid[row][column])
                .Select(nextRow => 1 + recursiveFunc((nextRow, column + 1)))
                .Prepend(0)
                .Max();
        });

        return Enumerable.Range(0, m).Max(row => dp.GetOrCalculate((row, 0)));
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
