namespace LeetCode.Problems._3736_Minimum_Moves_to_Equal_Array_Elements_III;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-169/problems/minimum-moves-to-equal-array-elements-iii/submissions/1824131505/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMoves(int[] nums)
    {
        var max = nums.Max();
        return nums.Select(num => max - num).Sum();
    }
}
