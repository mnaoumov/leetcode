namespace LeetCode.Problems._1260_Shift_2D_Grid;

/// <summary>
/// https://leetcode.com/problems/shift-2d-grid/submissions/2075136071/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var ans = Enumerable.Range(0, m).Select(IList<int> (_) => new int[n]).ToArray();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var offset = row * n + column;
                var shiftedOffset = offset + k;
                shiftedOffset %= (m * n);

                var newRow = shiftedOffset / n;
                var newColumn = shiftedOffset % n;
                ans[newRow][newColumn] = grid[row][column];
            }
        }

        return ans;
    }
}
