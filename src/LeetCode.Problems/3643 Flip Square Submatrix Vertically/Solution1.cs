namespace LeetCode.Problems._3643_Flip_Square_Submatrix_Vertically;

/// <summary>
/// https://leetcode.com/problems/flip-square-submatrix-vertically/submissions/1954354262/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        var ans = grid.Select(row => row.ToArray()).ToArray();

        for (var row = x; row < x + k; row++)
        {
            for (var column = y; column < y + k; column++)
            {
                ans[row][column] = grid[2 * x + k - 1 - row][column];
            }
        }

        return ans;
    }
}
