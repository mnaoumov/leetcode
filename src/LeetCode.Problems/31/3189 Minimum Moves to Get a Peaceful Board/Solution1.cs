namespace LeetCode.Problems._3189_Minimum_Moves_to_Get_a_Peaceful_Board;

/// <summary>
/// https://leetcode.com/submissions/detail/1356990019/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMoves(int[][] rooks)
    {
        var orderedByRows = rooks.OrderBy(r => r[0]).ToArray();
        var orderedByColumns = rooks.OrderBy(r => r[1]).ToArray();

        return orderedByRows.Select((r, i) => Math.Abs(r[0] - i)).Sum() +
               orderedByColumns.Select((r, i) => Math.Abs(r[1] - i)).Sum();
    }
}
