namespace LeetCode.Problems._3487_Maximum_Unique_Subarray_Sum_After_Deletion;

/// <summary>
/// https://leetcode.com/problems/maximum-unique-subarray-sum-after-deletion/submissions/1710385004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSum(int[] nums)
    {
        nums = nums.Distinct().ToArray();
        var positives = nums.Where(num => num > 0).ToArray();
        return positives.Length > 0 ? positives.Sum() : nums.Max();
    }
}
