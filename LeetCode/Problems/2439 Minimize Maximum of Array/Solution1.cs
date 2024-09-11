

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2439_Minimize_Maximum_of_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-89/submissions/detail/823040553/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimizeArrayValue(int[] nums)
    {
        var minPossibleResult = Math.Max(nums[0], (int) Math.Ceiling(nums.Average()));

        if (nums.Max() <= minPossibleResult)
        {
            return minPossibleResult;
        }

        for (var i = nums.Length - 1; i >= 1; i--)
        {
            if (nums[i] > minPossibleResult)
            {
                nums[i - 1] += nums[i] - minPossibleResult;
                nums[i] = minPossibleResult;
            }
        }

        return nums.Max();
    }
}
