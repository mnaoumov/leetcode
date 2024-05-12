using JetBrains.Annotations;

namespace LeetCode.Problems._2653_Sliding_Subarray_Beauty;

[PublicAPI]
public interface ISolution
{
    public int[] GetSubarrayBeauty(int[] nums, int k, int x);
}
