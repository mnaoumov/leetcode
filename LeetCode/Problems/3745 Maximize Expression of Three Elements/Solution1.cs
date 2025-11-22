namespace LeetCode.Problems._3745_Maximize_Expression_of_Three_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-476/problems/maximize-expression-of-three-elements/submissions/1830833697/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximizeExpressionOfThree(int[] nums)
    {
        Array.Sort(nums);
        return nums[^1] + nums[^2] - nums[0];
    }
}
