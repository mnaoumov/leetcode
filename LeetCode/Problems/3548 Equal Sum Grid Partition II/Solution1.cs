namespace LeetCode.Problems._3548_Equal_Sum_Grid_Partition_II;

/// <summary>
/// https://leetcode.com/problems/equal-sum-grid-partition-ii/submissions/1960534390/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        var totalSum = grid.Select(row => row.Select(value => (long) value).Sum()).Sum();

        var currentGrid = grid;

        for (var i = 0; i < 4; i++)
        {
            if (CanPartitionGrid2(currentGrid, totalSum))
            {
                return true;
            }

            if (i < 3)
            {
                currentGrid = Rotate(currentGrid);
            }
        }

        return false;
    }

    private static int[][] Rotate(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var rotated = Enumerable.Range(0, n).Select(_ => new int[m]).ToArray();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                rotated[n - 1 - j][i] = grid[i][j];
            }
        }

        return rotated;
    }

    private static bool CanPartitionGrid2(int[][] grid, long totalSum)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        if (m == 1)
        {
            return false;
        }

        var topSum = 0L;

        var topSeen = new HashSet<long>();

        for (var i = 0; i < m - 1; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var value = grid[i][j];
                topSeen.Add(value);
                topSum += value;
            }

            var valueToRemove = 2 * topSum - totalSum;

            if (valueToRemove == 0)
            {
                return true;
            }

            if (!topSeen.Contains(valueToRemove))
            {
                continue;
            }

            if (i == 0)
            {
                if (n > 1 && (grid[0][0] == valueToRemove || grid[0][n - 1] == valueToRemove))
                {
                    return true;
                }

                continue;
            }


            if (n > 1)
            {
                return true;
            }

            if (i > 0 && (grid[0][0] == valueToRemove || grid[i][0] == valueToRemove))
            {
                return true;
            }
        }

        return false;
    }
}
