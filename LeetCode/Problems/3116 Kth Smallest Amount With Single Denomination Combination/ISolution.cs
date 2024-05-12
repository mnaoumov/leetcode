using JetBrains.Annotations;

namespace LeetCode.Problems._3116_Kth_Smallest_Amount_With_Single_Denomination_Combination;

[PublicAPI]
public interface ISolution
{
    public long FindKthSmallest(int[] coins, int k);
}
