using JetBrains.Annotations;

namespace LeetCode._0361_Bomb_Enemy;

/// <summary>
/// https://leetcode.com/submissions/detail/945259840/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxKilledEnemies(char[][] grid)
    {
        const char wall = 'W';
        const char enemy = 'E';

        var m = grid.Length;
        var n = grid[0].Length;
        var allDirections = Enum.GetValues<Direction>().Except(new[] { Direction.All }).ToArray();

        var deltas = new Dictionary<Direction, (int dRow, int dColumn)>
        {
            [Direction.Up] = (-1, 0),
            [Direction.Down] = (1, 0),
            [Direction.Left] = (0, -1),
            [Direction.Right] = (0, 1)
        };

        var dp = new DynamicProgramming<(int row, int column, Direction direction), int>((key, recursiveFunc) =>
        {
            var (row, column, direction) = key;

            if (row < 0 || column < 0 || row >= m || column >= n)
            {
                return 0;
            }

            if (grid[row][column] == wall)
            {
                return 0;
            }

            if (direction == Direction.All)
            {
                return grid[row][column] == enemy
                    ? 0
                    : allDirections.Sum(direction2 => recursiveFunc((row, column, direction2)));
            }

            var (dRow, dColumn) = deltas[direction];
            return (grid[row][column] == enemy ? 1 : 0) + recursiveFunc((row + dRow, column + dColumn, direction));
        });

        return (from row in Enumerable.Range(0, m)
                from column in Enumerable.Range(0, n)
                select dp.GetOrCalculate((row, column, Direction.All)))
            .Max();
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
        All,
        Left,
        Right,
        Up,
        Down
    }
}
