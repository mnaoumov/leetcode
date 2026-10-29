namespace LeetCode.Problems._3151_Special_Array_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-398/submissions/detail/1261747700/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsArraySpecial(int[] nums) => Enumerable.Range(0, nums.Length - 1).All(i => Math.Abs(nums[i + 1] - nums[i]) % 2 == 1);
}
