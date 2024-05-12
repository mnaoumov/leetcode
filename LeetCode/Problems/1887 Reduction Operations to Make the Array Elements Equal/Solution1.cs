using JetBrains.Annotations;

namespace LeetCode.Problems._1887_Reduction_Operations_to_Make_the_Array_Elements_Equal;

/// <summary>
/// https://leetcode.com/submissions/detail/1102314641/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ReductionOperations(int[] nums)
    {
        var counts = nums.GroupBy(num => num).OrderByDescending(g => g.Key).Select(g => g.Count()).ToArray();
        return counts.Select((t, i) => t * (counts.Length - 1 - i)).Sum();
    }
}
