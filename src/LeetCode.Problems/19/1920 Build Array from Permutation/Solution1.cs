namespace LeetCode.Problems._1920_Build_Array_from_Permutation;

/// <summary>
/// https://leetcode.com/problems/build-array-from-permutation/submissions/1626538747/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] BuildArray(int[] nums) => Enumerable.Range(0, nums.Length).Select(i => nums[nums[i]]).ToArray();
}
