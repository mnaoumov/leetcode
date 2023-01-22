using JetBrains.Annotations;

namespace LeetCode._2542_Maximum_Subsequence_Score;

[PublicAPI]
public interface ISolution
{
    public long MaxScore(int[] nums1, int[] nums2, int k);
}
