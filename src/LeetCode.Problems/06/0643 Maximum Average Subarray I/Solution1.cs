namespace LeetCode.Problems._0643_Maximum_Average_Subarray_I;

/// <seealso href="https://leetcode.com/submissions/detail/855210155/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double FindMaxAverage(int[] nums, int k)
    {
        var sum = nums.Take(k).Sum();
        var maxSum = sum;

        for (var i = k; i < nums.Length; i++)
        {
            sum = sum - nums[i - k] + nums[i];
            maxSum = Math.Max(maxSum, sum);
        }

        return (double) maxSum / k;
    }
}
