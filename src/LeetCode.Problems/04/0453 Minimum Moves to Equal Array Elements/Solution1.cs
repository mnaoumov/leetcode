namespace LeetCode.Problems._0453_Minimum_Moves_to_Equal_Array_Elements;

/// <summary>
/// https://leetcode.com/problems/minimum-moves-to-equal-array-elements/submissions/2186571087/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMoves(int[] nums) => nums.Sum() - nums.Length * nums.Min();
}
