namespace LeetCode.Problems._2500_Delete_Greatest_Value_in_Each_Row;

/// <summary>
/// https://leetcode.com/submissions/detail/858991067/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DeleteGreatestValue(int[][] grid)
    {
        var sortedRows = grid.Select(row => row.OrderByDescending(x => x).ToArray()).ToArray();
        var n = grid[0].Length;
        return Enumerable.Range(0, n).Select(columnIndex => sortedRows.Select(row => row[columnIndex]).Max()).Sum();
    }
}
