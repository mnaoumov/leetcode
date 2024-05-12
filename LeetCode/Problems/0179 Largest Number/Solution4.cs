using JetBrains.Annotations;

namespace LeetCode.Problems._0179_Largest_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/897238762/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public string LargestNumber(int[] nums) => nums.All(x => x == 0)
        ? "0"
        : string.Concat(nums.Select(num => num.ToString())
            .OrderByDescending(x => x,
                Comparer<string>.Create((x, y) => string.Compare($"{x}{y}", $"{y}{x}", StringComparison.Ordinal))));
}
