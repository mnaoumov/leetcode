using JetBrains.Annotations;

namespace LeetCode._0703_Kth_Largest_Element_in_a_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/908028755/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IKthLargest Create(int k, int[] nums)
    {
        return new KthLargest1(k, nums);
    }
}
