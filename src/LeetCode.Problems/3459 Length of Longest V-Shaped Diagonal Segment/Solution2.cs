namespace LeetCode.Problems._3459_Length_of_Longest_V_Shaped_Diagonal_Segment;

/// <summary>
/// https://leetcode.com/problems/length-of-longest-v-shaped-diagonal-segment/submissions/1749621863/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LenOfVDiagonal(int[][] grid)
    {
        var n = grid.Length;
        var m = grid[0].Length;

        var directions = new[]
        {
            (-1, -1),
            (-1, 1),
            (1, -1),
            (1, 1)
        };

        var dp = new DynamicProgramming<(int row, int column, int dRow, int dColumn, bool canChangeDirection), int>((key, recursiveFunc) =>
        {
            var (row, column, dRow, dColumn, canChangeDirection) = key;

            var nextRow = row + dRow;
            var nextColumn = column + dColumn;
            var value = grid[row][column];
            var nextValue = value switch
            {
                0 => 2,
                1 => 2,
                2 => 0,
                _ => throw new ArgumentOutOfRangeException()
            };
            var isNextValid = nextRow >= 0 && nextRow < n && nextColumn >= 0 && nextColumn < m && grid[nextRow][nextColumn] == nextValue;
            var ans = isNextValid
                ? 1 + recursiveFunc((nextRow, nextColumn, dRow, dColumn, canChangeDirection))
                : 1;

            if (value == 1 || !canChangeDirection)
            {
                return ans;
            }

            return Math.Max(ans, recursiveFunc((row, column, dColumn, -dRow, false)));
        });

        var ans = 0;

        for (var row = 0; row < n; row++)
        {
            for (var column = 0; column < m; column++)
            {
                if (grid[row][column] != 1)
                {
                    continue;
                }

                foreach (var (dRow, dColumn) in directions)
                {
                    ans = Math.Max(ans, dp.GetOrCalculate((row, column, dRow, dColumn, true)));
                }
            }
        }

        return ans;
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
