namespace LeetCode.Problems._2567_Minimum_Score_by_Changing_Two_Elements;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-98/submissions/detail/900374141/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimizeSum(int[] nums)
    {
        var n = nums.Length;

        if (n == 3)
        {
            return 0;
        }

        Array.Sort(nums);

        return new[] { nums[n - 3] - nums[0], nums[n - 1] - nums[2], nums[n - 2] - nums[1] }.Min();
    }
}
