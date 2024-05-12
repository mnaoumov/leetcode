using JetBrains.Annotations;

namespace LeetCode.Problems._0523_Continuous_Subarray_Sum;

[PublicAPI]
public interface ISolution
{
    public bool CheckSubarraySum(int[] nums, int k);
}
