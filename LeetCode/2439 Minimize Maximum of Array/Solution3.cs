using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._2439_Minimize_Maximum_of_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-89/submissions/detail/823058750/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinimizeArrayValue(int[] nums)
    {
        var runningSum = nums.Sum(num => (long) num);

        for (var i = nums.Length - 1; i >= 1; i--)
        {
            var minPossibleResult = Math.Max(nums[0], (int) Math.Ceiling((double) runningSum / (i + 1)));

            if (nums[i] > minPossibleResult)
            {
                nums[i - 1] += nums[i] - minPossibleResult;
                nums[i] = minPossibleResult;
            }

            runningSum -= nums[i];
        }

        return nums.Max();
    }
}
