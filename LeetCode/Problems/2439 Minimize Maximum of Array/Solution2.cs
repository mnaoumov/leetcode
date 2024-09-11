using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2439_Minimize_Maximum_of_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-89/submissions/detail/823050566/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimizeArrayValue(int[] nums)
    {
        for (var i = nums.Length - 1; i >= 1; i--)
        {
            var minPossibleResult = Math.Max(nums[0], (int) Math.Ceiling(nums[0..(i + 1)].Average()));

            if (nums[i] > minPossibleResult)
            {
                nums[i - 1] += nums[i] - minPossibleResult;
                nums[i] = minPossibleResult;
            }
        }

        return nums.Max();
    }
}
