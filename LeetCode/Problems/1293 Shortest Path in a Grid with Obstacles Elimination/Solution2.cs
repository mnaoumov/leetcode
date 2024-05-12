using JetBrains.Annotations;

namespace LeetCode.Problems._1293_Shortest_Path_in_a_Grid_with_Obstacles_Elimination;

/// <summary>
/// https://leetcode.com/submissions/detail/833608599/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int ShortestPath(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int impossible = -1;
        const int isObstacle = 1;

        var visited = new bool[m, n];

        return Get(0, 0, k);

        int Get(int row, int column, int obstacleEliminationsLeft)
        {
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
                Get(row + 1, column, obstacleEliminationsLeft),
                Get(row - 1, column, obstacleEliminationsLeft),
                Get(row, column + 1, obstacleEliminationsLeft),
                Get(row, column - 1, obstacleEliminationsLeft)
            };
            results = results.Where(x => x != impossible).ToArray();

            visited[row, column] = false;

            return results.Any() ? 1 + results.Min() : impossible;
        }
    }
}
