

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0179_Largest_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/896863315/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string LargestNumber(int[] nums) => string.Concat(nums.Select(num => num.ToString()).OrderByDescending(x => x, Comparer<string>.Create((x, y) => $"{x}{y}".CompareTo($"{y}{x}"))));
}
