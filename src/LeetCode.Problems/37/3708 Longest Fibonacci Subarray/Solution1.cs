namespace LeetCode.Problems._3708_Longest_Fibonacci_Subarray;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-167/problems/longest-fibonacci-subarray/submissions/1798383931/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestSubarray(int[] nums)
    {
        var ans = 2;
        var length = 2;

        for (var i = 2; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + nums[i - 2])
            {
                length++;
                ans = Math.Max(ans, length);
            }
            else
            {
                length = 2;
            }
        }

        return ans;
    }
}
