using JetBrains.Annotations;

namespace LeetCode.Problems._2444_Count_Subarrays_With_Fixed_Bounds;

[PublicAPI]
public interface ISolution
{
    public long CountSubarrays(int[] nums, int minK, int maxK);
}
