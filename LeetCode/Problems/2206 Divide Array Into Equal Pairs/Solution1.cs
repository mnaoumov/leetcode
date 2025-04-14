namespace LeetCode.Problems._2206_Divide_Array_Into_Equal_Pairs;

/// <summary>
/// https://leetcode.com/problems/divide-array-into-equal-pairs/submissions/1576226768/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool DivideArray(int[] nums) => nums.GroupBy(num => num).All(g => g.Count() % 2 == 0);
}
