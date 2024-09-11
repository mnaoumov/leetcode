namespace LeetCode.Problems._2766_Relocate_Marbles;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-108/submissions/detail/989390565/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
    {
        var positions = new SortedSet<int>(nums);

        var n = moveFrom.Length;

        for (var i = 0; i < n; i++)
        {
            positions.Remove(moveFrom[i]);
            positions.Add(moveTo[i]);
        }

        return positions.ToArray();
    }
}
