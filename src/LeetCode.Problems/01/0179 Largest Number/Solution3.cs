
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0179_Largest_Number;

/// <seealso href="https://leetcode.com/submissions/detail/896869787/">Submission</seealso>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string LargestNumber(int[] nums) => nums.All(x => x == 0)
        ? "0"
        : string.Concat(nums.Select(num => num.ToString())
            .OrderByDescending(x => x, Comparer<string>.Create((x, y) => $"{x}{y}".CompareTo($"{y}{x}"))));
}
