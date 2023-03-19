using JetBrains.Annotations;

namespace LeetCode._2592_Maximize_Greatness_of_an_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-100/submissions/detail/917492137/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximizeGreatness(int[] nums)
    {
        Array.Sort(nums);
        var index = Array.BinarySearch(nums, nums[0] + 1);

        if (index < 0)
        {
            index = ~index;
        }

        return nums.Length - index;
    }
}
