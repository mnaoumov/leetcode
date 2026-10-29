namespace LeetCode.Problems._3195_Find_the_Minimum_Area_to_Cover_All_Ones_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-403/submissions/detail/1297240990/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumArea(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var minRow = m;
        var maxRow = -1;
        var minColumn = n;
        var maxColumn = -1;


        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                if (grid[row][column] != 1)
                {
                    continue;
                }

                minRow = Math.Min(minRow, row);
                maxRow = Math.Max(maxRow, row);
                minColumn=Math.Min(minColumn, column);
                maxColumn = Math.Max(maxColumn, column);
            }
        }

        return (maxRow - minRow + 1) * (maxColumn - minColumn + 1);
    }
}
