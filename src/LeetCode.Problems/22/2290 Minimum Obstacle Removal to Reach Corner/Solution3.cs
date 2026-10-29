namespace LeetCode.Problems._2290_Minimum_Obstacle_Removal_to_Reach_Corner;

/// <summary>
/// https://leetcode.com/submissions/detail/1464669797/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinimumObstacles(int[][] grid)
    {
        var directions = new (int dRow, int dColumn)[] { (0, 1), (0, -1), (-1, 0), (1, 0) };

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

        minRemovalCounts[0, 0] = grid[0][0];

        var pq = new PriorityQueue<(int row, int column, int minRemovalCount), int>();
        pq.Enqueue((0, 0, minRemovalCounts[0, 0]), minRemovalCounts[0, 0]);

        while (pq.Count > 0)
        {
            var (row, column, minRemovalCount) = pq.Dequeue();
            if (row == m - 1 && column == n - 1)
            {
                return minRemovalCount;
            }

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;

                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                var nextMinRemovalCount = minRemovalCount + grid[nextRow][nextColumn];
                if (nextMinRemovalCount >= minRemovalCounts[nextRow, nextColumn])
                {
                    continue;
                }

                minRemovalCounts[nextRow, nextColumn] = nextMinRemovalCount;
                pq.Enqueue((nextRow, nextColumn, nextMinRemovalCount), nextMinRemovalCount);
            }
        }

        return minRemovalCounts[m - 1, n - 1];
    }
}