using JetBrains.Annotations;

namespace LeetCode._2569_Handling_Sum_Queries_After_Update;

[PublicAPI]
public interface ISolution
{
    public long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries);
}
