using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0560_Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/submissions/detail/196731152/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var result = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                var sum = 0;
                for (int m = i; m <= j; m++)
                {
                    sum += nums[m];
                }

                if (sum == k)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
