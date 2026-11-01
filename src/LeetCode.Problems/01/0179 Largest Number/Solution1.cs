namespace LeetCode.Problems._0179_Largest_Number;

/// <seealso href="https://leetcode.com/submissions/detail/896853487/"/>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string LargestNumber(int[] nums) => string.Concat(nums.Select(num => num.ToString()).OrderByDescending(x => x));
}
