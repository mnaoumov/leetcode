namespace LeetCode.Problems._1800_Maximum_Ascending_Subarray_Sum;

/// <summary>
/// https://leetcode.com/problems/maximum-ascending-subarray-sum/submissions/1530618769/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxAscendingSum(int[] nums)
    {
        var ans = 0;
        var sum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (i == 0 || nums[i] > nums[i - 1])
            {
                sum += nums[i];
            }
            else
            {
                sum = nums[i];
            }
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}
