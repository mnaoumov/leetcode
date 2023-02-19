using JetBrains.Annotations;

namespace LeetCode._2428_Maximum_Sum_of_an_Hourglass;

/// <summary>
/// https://leetcode.com/submissions/detail/899230468/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSum(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var result = 0;

        for (var i = 0; i < m - 2; i++)
        {
            for (var j = 0; j < n - 2; j++)
            {
                var sum = grid[i][j] + grid[i][j + 1] + grid[i][j + 2] + grid[i + 1][j + 1] + grid[i + 2][j] +
                          grid[i + 2][j + 1] + grid[i + 2][j + 2];
                result = Math.Max(result, sum);
            }
        }

        return result;
    }
}
