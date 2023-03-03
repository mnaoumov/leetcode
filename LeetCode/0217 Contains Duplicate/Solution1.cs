using JetBrains.Annotations;

namespace LeetCode._0217_Contains_Duplicate;

/// <summary>
/// https://leetcode.com/submissions/detail/898935842/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();
        return nums.Any(num => !set.Add(num));
    }
}
