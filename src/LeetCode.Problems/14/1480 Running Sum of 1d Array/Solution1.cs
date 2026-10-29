namespace LeetCode.Problems._1480_Running_Sum_of_1d_Array;

/// <summary>
/// https://leetcode.com/problems/running-sum-of-1d-array/submissions/845556407/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] RunningSum(int[] nums)
    {
        var result = new int[nums.Length];

        result[0] = nums[0];

        for (var i = 1; i < result.Length; i++)
        {
            result[i] = result[i - 1] + nums[i];
        }

        return result;
    }
}
