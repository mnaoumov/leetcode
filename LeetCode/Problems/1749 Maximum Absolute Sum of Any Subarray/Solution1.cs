namespace LeetCode.Problems._1749_Maximum_Absolute_Sum_of_Any_Subarray;

/// <summary>
/// https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray/submissions/1555525518/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        var maxPrefixSum = 0;
        var minPrefixSum = 0;
        var prefixSum = 0;
        var ans = 0;

        foreach (var num in nums)
        {
            prefixSum += num;
            minPrefixSum = Math.Min(minPrefixSum, prefixSum);
            maxPrefixSum = Math.Max(maxPrefixSum, prefixSum);

            ans = Math.Max(ans, prefixSum - minPrefixSum);
            ans = Math.Max(ans, maxPrefixSum - prefixSum);
        }

        return ans;
    }
}
