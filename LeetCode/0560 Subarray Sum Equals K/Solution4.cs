using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0560_Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/submissions/detail/196740143/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            var sum = 0;
            for (int j = i; j < nums.Length; j++)
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
