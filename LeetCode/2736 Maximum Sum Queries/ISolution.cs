using JetBrains.Annotations;

namespace LeetCode._2736_Maximum_Sum_Queries;

[PublicAPI]
public interface ISolution
{
    public int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries);
}
