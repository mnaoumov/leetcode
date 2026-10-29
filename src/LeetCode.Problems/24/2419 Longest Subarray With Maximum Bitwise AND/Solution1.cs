namespace LeetCode.Problems._2419_Longest_Subarray_With_Maximum_Bitwise_AND;

/// <summary>
/// https://leetcode.com/submissions/detail/1389425263/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestSubarray(int[] nums)
    {
        var max = nums.Max();
        var ans = 1;

        var sequenceLength = 0;
        foreach (var num in nums)
        {
            if (num == max)
            {
                sequenceLength++;
                ans = Math.Max(ans, sequenceLength);
            }
            else
            {
                sequenceLength = 0;
            }
        }

        return ans;
    }
}
