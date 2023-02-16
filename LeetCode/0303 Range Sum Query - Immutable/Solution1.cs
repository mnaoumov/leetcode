using JetBrains.Annotations;

namespace LeetCode._0303_Range_Sum_Query___Immutable;

/// <summary>
/// https://leetcode.com/submissions/detail/898931924/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INumArray Create(int[] nums)
    {
        return new NumArray1(nums);
    }
}
