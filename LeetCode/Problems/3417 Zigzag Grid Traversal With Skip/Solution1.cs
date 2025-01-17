namespace LeetCode.Problems._3417_Zigzag_Grid_Traversal_With_Skip;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-432/submissions/detail/1505653209/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> ZigzagTraversal(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var ans = new List<int>();

        for (var row = 0; row < m; row++)
        {
            var initialColumn = row % 2 == 0 ? 0 : 2 * (n / 2) - 1;
            var step = row % 2 == 0 ? 2 : -2;

            for (var column = initialColumn; 0 <= column && column < n; column += step)
            {
                ans.Add(grid[row][column]);
            }
        }

        return ans;
    }
}
