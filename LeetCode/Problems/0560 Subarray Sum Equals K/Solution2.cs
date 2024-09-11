

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0560_Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/submissions/detail/196732085/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SubarraySum(int[] nums, int k)
    {
        var result = 0;
        var sums = new int[nums.Length, nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            sums[i, i] = nums[i];

            for (int j = i + 1; j < nums.Length; j++)
            {
                sums[i, j] = sums[i, j - 1] + nums[j];

                if (sums[i, j] == k)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
