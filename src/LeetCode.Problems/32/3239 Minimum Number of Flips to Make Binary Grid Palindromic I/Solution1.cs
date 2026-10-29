namespace LeetCode.Problems._3239_Minimum_Number_of_Flips_to_Make_Binary_Grid_Palindromic_I;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinFlips(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var rowFlips = 0;
        var columnFlips = 0;

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n / 2; column++)
            {
                if (grid[row][column] != grid[row][n - column - 1])
                {
                    rowFlips++;
                }
            }
        }

        for (var column = 0; column < n; column++)
        {
            for (var row = 0; row < m / 2; row++)
            {
                if (grid[row][column] != grid[m - row - 1][column])
                {
                    columnFlips++;
                }
            }
        }

        return Math.Min(rowFlips, columnFlips);
    }
}
