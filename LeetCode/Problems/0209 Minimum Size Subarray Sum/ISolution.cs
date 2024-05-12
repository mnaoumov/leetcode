using JetBrains.Annotations;

namespace LeetCode.Problems._0209_Minimum_Size_Subarray_Sum;

[PublicAPI]
public interface ISolution
{
    public int MinSubArrayLen(int target, int[] nums);
}
