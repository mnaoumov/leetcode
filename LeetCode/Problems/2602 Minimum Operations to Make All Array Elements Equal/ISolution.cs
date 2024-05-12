using JetBrains.Annotations;

namespace LeetCode.Problems._2602_Minimum_Operations_to_Make_All_Array_Elements_Equal;

[PublicAPI]
public interface ISolution
{
    public IList<long> MinOperations(int[] nums, int[] queries);
}
