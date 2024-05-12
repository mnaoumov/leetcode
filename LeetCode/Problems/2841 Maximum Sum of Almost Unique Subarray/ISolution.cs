using JetBrains.Annotations;

namespace LeetCode.Problems._2841_Maximum_Sum_of_Almost_Unique_Subarray;

[PublicAPI]
public interface ISolution
{
    public long MaxSum(IList<int> nums, int m, int k);
}
