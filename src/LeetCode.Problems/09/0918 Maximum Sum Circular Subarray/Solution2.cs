namespace LeetCode.Problems._0918_Maximum_Sum_Circular_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/880852060/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return nums[0];
        }

        var prefixSums = new int[n + 1];
        prefixSums[1] = nums[0];
        var subarrayMax = nums[0];
        var circularSubarrayMax = -nums[0];
        var maxPrefixSum = Math.Max(0, nums[0]);
        var minPrefixSum = Math.Min(0, nums[0]);

        for (var i = 2; i <= n; i++)
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
