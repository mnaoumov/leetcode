namespace LeetCode.Problems._1293_Shortest_Path_in_a_Grid_with_Obstacles_Elimination;

/// <summary>
/// https://leetcode.com/submissions/detail/833637646/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int ShortestPath(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int impossible = -1;
        const int isObstacle = 1;

        var visited = new HashSet<(int row, int column, int obstacleEliminationsLeft)>();

        var queue = new Queue<(int row, int column, int obstacleEliminationsLeft, int currentStep)>();
        queue.Enqueue((0, 0, k, 0));

        while (queue.Count > 0)
        {
            var (row, column, obstacleEliminationsLeft, currentStep) = queue.Dequeue();

            if (row < 0 || row >= m || column < 0 || column >= n)
            {
                continue;
            }

            if (grid[row][column] == isObstacle)
            {
                obstacleEliminationsLeft--;

                if (obstacleEliminationsLeft < 0)
                {
                    continue;
                }
            }

            if (row == m - 1 && column == n - 1)
            {
                return currentStep;
            }

            if (!visited.Add((row, column, obstacleEliminationsLeft)))
            {
                continue;
            }

            foreach (var (dRow, dColumn) in new[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
            {
                queue.Enqueue((row + dRow, column + dColumn, obstacleEliminationsLeft, currentStep + 1));
            }
        }

        return impossible;
    }
}
