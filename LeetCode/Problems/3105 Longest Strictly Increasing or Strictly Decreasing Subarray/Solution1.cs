using JetBrains.Annotations;

namespace LeetCode.Problems._3105_Longest_Strictly_Increasing_or_Strictly_Decreasing_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/1225305895/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        var ans = 1;

        var increasingSubarrayLength = 1;
        var decreasingSubarrayLength = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];
            var previousNum = nums[i - 1];

            if (num > previousNum)
            {
                increasingSubarrayLength++;
                decreasingSubarrayLength = 1;
            }
            else if (num < previousNum)
            {
                decreasingSubarrayLength++;
                increasingSubarrayLength = 1;
            }
            else
            {
                increasingSubarrayLength = 1;
                decreasingSubarrayLength = 1;
            }

            ans = Math.Max(ans, increasingSubarrayLength);
            ans = Math.Max(ans, decreasingSubarrayLength);
        }

        return ans;
    }
}
