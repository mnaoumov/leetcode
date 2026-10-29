namespace LeetCode.Problems._3689_Maximum_Total_Subarray_Value_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-468/problems/maximum-total-subarray-value-i/submissions/1777624054/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxTotalValue(int[] nums, int k) => 1L * (nums.Max() - nums.Min()) * k;
}
