namespace LeetCode.Problems._1293_Shortest_Path_in_a_Grid_with_Obstacles_Elimination;

/// <summary>
/// https://leetcode.com/submissions/detail/833596816/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ShortestPath(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int impossible = -1;
        const int isObstacle = 1;

        var visited = new bool[m, n];

        var dp = new DynamicProgramming<(int row, int column, int obstacleEliminationsLeft), int>((key, calculateFunc) =>
        {
            var (row, column, obstacleEliminationsLeft) = key;

            if (row < 0 || row >= m || column < 0 || column >= n)
            {
                return impossible;
            }

            if (visited[row, column])
            {
                return impossible;
            }

            if (grid[row][column] == isObstacle)
            {
                if (obstacleEliminationsLeft == 0)
                {
                    return impossible;
                }

                obstacleEliminationsLeft--;
            }

            if (row == m - 1 && column == n - 1)
            {
                return 0;
            }

            visited[row, column] = true;

            var results = new[]
            {
                calculateFunc((row + 1, column, obstacleEliminationsLeft)),
                calculateFunc((row - 1, column, obstacleEliminationsLeft)),
                calculateFunc((row, column + 1, obstacleEliminationsLeft)),
                calculateFunc((row, column - 1, obstacleEliminationsLeft))
            }.Where(x => x != impossible).ToArray();

            visited[row, column] = false;

            return results.Any() ? 1 + results.Min() : impossible;
        });

        return dp.GetOrCalculate((row: 0, column: 0, obstacleEliminationsLeft: k));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }

}
