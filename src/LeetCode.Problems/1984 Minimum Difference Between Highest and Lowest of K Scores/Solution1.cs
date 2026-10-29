namespace LeetCode.Problems._1984_Minimum_Difference_Between_Highest_and_Lowest_of_K_Scores;

/// <summary>
/// https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/submissions/1896587986/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDifference(int[] nums, int k)
    {
        Array.Sort(nums);
        var n  = nums.Length;

        var ans = int.MaxValue;

        for (var i = 0; i <= n - k; i++)
        {
            ans = Math.Min(ans, nums[i + k - 1] - nums[i]);
        }

        return ans;
    }
}
