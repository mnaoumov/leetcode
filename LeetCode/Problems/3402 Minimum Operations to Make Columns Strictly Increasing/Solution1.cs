namespace LeetCode.Problems._3402_Minimum_Operations_to_Make_Columns_Strictly_Increasing;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-430/submissions/detail/1491109823/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var ans = 0;

        for (var j = 0; j < n; j++)
        {
            var previousValue = int.MinValue;

            for (var i = 0; i < m; i++)
            {
                if (grid[i][j] > previousValue)
                {
                    previousValue = grid[i][j];
                }
                else
                {
                    previousValue++;
                    ans += previousValue - grid[i][j];
                }
            }
        }

        return ans;
    }
}
