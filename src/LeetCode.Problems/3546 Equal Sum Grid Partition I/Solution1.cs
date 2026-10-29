namespace LeetCode.Problems._3546_Equal_Sum_Grid_Partition_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-449/problems/equal-sum-grid-partition-i/submissions/1630598084/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        var sum = grid.Sum(row => row.Sum(value => (long) value));

        if (sum % 2 != 0)
        {
            return false;
        }

        var m = grid.Length;
        var n = grid[0].Length;

        var rowSum = 0L;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                rowSum += grid[i][j];

                if (rowSum > sum / 2)
                {
                    break;
                }
            }

            if (rowSum == sum / 2)
            {
                return true;
            }

            if (rowSum > sum / 2)
            {
                break;
            }
        }

        var columnSum = 0L;

        for (var j = 0; j < n; j++)
        {
            for (var i = 0; i < m; i++)
            {
                columnSum += grid[i][j];

                if (columnSum > sum / 2)
                {
                    break;
                }
            }

            if (columnSum == sum / 2)
            {
                return true;
            }

            if (columnSum > sum / 2)
            {
                break;
            }
        }

        return false;
    }
}
