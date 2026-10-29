namespace LeetCode.Problems._2482_Difference_Between_Ones_and_Zeros_in_Row_and_Column;

/// <summary>
/// https://leetcode.com/submissions/detail/850249473/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] OnesMinusZeros(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var onesCountsByRow = grid.Select(row => row.Count(num => num == 1)).ToArray();
        var onesCountsByColumn = Enumerable.Range(0, n).Select(j => grid.Count(row => row[j] == 1)).ToArray();

        var result = new int[m][];

        for (var i = 0; i < m; i++)
        {
            result[i] = new int[n];
            for (var j = 0; j < n; j++)
            {
                result[i][j] = 2 * (onesCountsByRow[i] + onesCountsByColumn[j]) - m - n;
            }
        }

        return result;
    }
}
