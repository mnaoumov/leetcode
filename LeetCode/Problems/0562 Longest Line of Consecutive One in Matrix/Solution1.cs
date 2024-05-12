using JetBrains.Annotations;

namespace LeetCode._0562_Longest_Line_of_Consecutive_One_in_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/942719683/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestLine(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var deltas = new Dictionary<Direction, (int dRow, int dColumn)>
        {
            [Direction.Right] = (0, 1),
            [Direction.Down] = (1, 0),
            [Direction.RightDown] = (1, 1),
            [Direction.RightUp] = (-1, 1)
        };

        var dp = new DynamicProgramming<(int row, int column, Direction direction), int>((key, recursiveFunc) =>
        {
            var (row, column, direction) = key;

            if (row < 0 || column < 0 || row >= m || column >= n)
            {
                return 0;
            }

            if (mat[row][column] == 0)
            {
                return 0;
            }

            var (dRow, dColumn) = deltas[direction];

            return 1 + recursiveFunc((row + dRow, column + dColumn, direction));
        });

        return (
            from row in Enumerable.Range(0, m)
            from column in Enumerable.Range(0, n)
            from direction in Enum.GetValues<Direction>()
            select dp.GetOrCalculate((row, column, direction))
        ).Max();
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

    private enum Direction
    {
        Right,
        Down,
        RightDown,
        RightUp
    }
}
