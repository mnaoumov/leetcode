using JetBrains.Annotations;

namespace LeetCode.Problems._0373_Find_K_Pairs_with_Smallest_Sums;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k);
}
