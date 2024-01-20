using JetBrains.Annotations;

namespace LeetCode._3012_Minimize_Length_of_Array_Using_Operations;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-122/submissions/detail/1151661527/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumArrayLength(int[] nums)
    {
        Array.Sort(nums);

        var minCount = nums.TakeWhile(num => num == nums[0]).Count();
        return (minCount + 1) / 2;
    }
}
