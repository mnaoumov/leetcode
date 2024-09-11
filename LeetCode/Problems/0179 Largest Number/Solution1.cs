using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0179_Largest_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/896853487/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string LargestNumber(int[] nums) => string.Concat(nums.Select(num => num.ToString()).OrderByDescending(x => x));
}
