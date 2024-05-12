using JetBrains.Annotations;

namespace LeetCode.Problems._0229_Majority_Element_II;

/// <summary>
/// https://leetcode.com/submissions/detail/925591975/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> MajorityElement(int[] nums)
    {
        var minCount = nums.Length / 3;
        return nums.GroupBy(num => num).Where(g => g.Count() > minCount).Select(g => g.Key).ToArray();
    }
}
