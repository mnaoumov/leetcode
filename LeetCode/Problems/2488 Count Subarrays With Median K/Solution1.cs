using JetBrains.Annotations;

namespace LeetCode._2488_Count_Subarrays_With_Median_K;

/// <summary>
/// https://leetcode.com/submissions/detail/855914886/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        var balances = new int[n];

        for (var i = 0; i < n; i++)
        {
            balances[i] = (i > 0 ? balances[i - 1] : 0) + Math.Sign(nums[i] - k);
        }

        var index = Array.IndexOf(nums, k);

        var result = 0;

        for (var leftIndex = index; leftIndex >= 0; leftIndex--)
        {
            for (var rightIndex = index; rightIndex < nums.Length; rightIndex++)
            {
                var balance = balances[rightIndex] - (leftIndex > 0 ? balances[leftIndex - 1] : 0);

                if (balance is 0 or 1)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
