namespace LeetCode.Problems._2290_Minimum_Obstacle_Removal_to_Reach_Corner;

/// <summary>
/// https://leetcode.com/submissions/detail/1464648063/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinimumObstacles(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var minRemovalCounts = new int[m, n];

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                minRemovalCounts[row, column] = int.MaxValue;
            }
        }

        var queue = new Queue<(int row, int column, int removalCount)>();
        queue.Enqueue((0, 0, 0));

        var directions = new (int dRow, int dColumn)[] { (0, 1), (0, -1), (-1, 0), (1, 0) };

        var ans = int.MaxValue;

        while (queue.Count > 0)
        {
            var (row, column, removalCount) = queue.Dequeue();

            if (row == m - 1 && column == n - 1)
            {
                ans = Math.Min(ans, removalCount);
                continue;
            }

            if (minRemovalCounts[row, column] <= removalCount)
            {
                continue;
            }

            minRemovalCounts[row, column] = removalCount;

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;

                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                var nextRemovalCount = removalCount + (grid[nextRow][nextColumn] == 1 ? 1 : 0);
                queue.Enqueue((nextRow, nextColumn, nextRemovalCount));
            }
        }

        return ans;
    }
}
