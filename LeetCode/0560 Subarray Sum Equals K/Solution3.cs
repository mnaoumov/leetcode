using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0560_Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/submissions/detail/196732754/
/// </summary>
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var result = 0;
        var sums = new int[nums.Length, nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                sums[i, j] = (j >= 1 ? sums[i, j - 1] : 0) + nums[j];

                if (sums[i, j] == k)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
