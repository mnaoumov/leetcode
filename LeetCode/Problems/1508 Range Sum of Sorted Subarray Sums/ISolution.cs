using JetBrains.Annotations;

namespace LeetCode._1508_Range_Sum_of_Sorted_Subarray_Sums;

[PublicAPI]
public interface ISolution
{
    public int RangeSum(int[] nums, int n, int left, int right);
}
