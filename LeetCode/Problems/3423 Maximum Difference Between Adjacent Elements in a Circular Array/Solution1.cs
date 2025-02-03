namespace LeetCode.Problems._3423_Maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-148/problems/maximum-difference-between-adjacent-elements-in-a-circular-array/submissions/1512562027/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxAdjacentDistance(int[] nums)
    {
        var n = nums.Length;

        var ans = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            ans = Math.Max(ans, Math.Abs(nums[i] - nums[(i - 1 + n) % n]));
        }

        return ans;
    }
}
