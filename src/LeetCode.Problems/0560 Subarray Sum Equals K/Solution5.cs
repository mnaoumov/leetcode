namespace LeetCode.Problems._0560_Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/submissions/detail/856483564/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var sum = 0;
            for (var j = i; j < nums.Length; j++)
            {
                sum += nums[j];

                if (sum == k)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
