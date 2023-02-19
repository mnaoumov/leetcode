using JetBrains.Annotations;

namespace LeetCode._2567_Minimum_Score_by_Changing_Two_Elements;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-98/submissions/detail/900370175/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimizeSum(int[] nums)
    {
        var n = nums.Length;

        if (n == 3)
        {
            return 0;
        }

        Array.Sort(nums);

        return Math.Min(nums[n - 3] - nums[0], nums[^1] - nums[2]);
    }
}
