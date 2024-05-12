using JetBrains.Annotations;

namespace LeetCode._0918_Maximum_Sum_Circular_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/880850275/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new int[n + 1];
        var maxPrefixSum = 0;
        var minPrefixSum = 0;
        var subarrayMax = int.MinValue;
        var circularSubarrayMax = int.MinValue;

        for (var i = 1; i <= n; i++)
        {
            var prefixSum = prefixSums[i - 1] + nums[i - 1];
            prefixSums[i] = prefixSum;
            subarrayMax = Math.Max(subarrayMax, prefixSum - minPrefixSum);

            if (i < n)
            {
                circularSubarrayMax = Math.Max(circularSubarrayMax, maxPrefixSum - prefixSum);
            }

            maxPrefixSum = Math.Max(maxPrefixSum, prefixSum);
            minPrefixSum = Math.Min(minPrefixSum, prefixSum);
        }

        circularSubarrayMax += prefixSums[n];

        return Math.Max(subarrayMax, circularSubarrayMax);
    }
}
