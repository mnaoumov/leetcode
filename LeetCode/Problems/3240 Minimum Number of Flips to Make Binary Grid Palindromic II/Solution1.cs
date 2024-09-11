namespace LeetCode.Problems._3240_Minimum_Number_of_Flips_to_Make_Binary_Grid_Palindromic_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-136/submissions/detail/1343179396/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinFlips(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var flips = 0;
        var oneCount = 0;
        var hasSwitchingPair = false;

        for (var row = 0; row <= (m - 1) / 2; row++)
        {
            for (var column = 0; column <= (n - 1) / 2; column++)
            {
                var isMiddleRow = row == m - 1 - row;
                var isMiddleColumn = column == n - 1 - column;

                var value = grid[row][column];

                if (isMiddleRow && isMiddleColumn)
                {
                    if (value == 1)
                    {
                        flips++;
                    }

                    continue;
                }

                var values = new List<int> { value };

                if (!isMiddleRow)
                {
                    values.Add(grid[m - row - 1][column]);
                }

                if (!isMiddleColumn)
                {
                    values.Add(grid[row][n - column - 1]);
                }

                if (!isMiddleRow && !isMiddleColumn)
                {
                    values.Add(grid[m - row - 1][n - column - 1]);
                }

                var count = values.Count(other => other == value);
                flips += Math.Min(count, values.Count - count);

                if (values.Count != 2)
                {
                    continue;
                }

                if (value == 1)
                {
                    oneCount += 2;
                }

                if (count == 1)
                {
                    hasSwitchingPair = true;
                }
            }
        }


        if (oneCount % 4 == 2 && !hasSwitchingPair)
        {
            flips += 2;
        }

        return flips;
    }
}
