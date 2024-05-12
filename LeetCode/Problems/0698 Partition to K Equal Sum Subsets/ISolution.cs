using JetBrains.Annotations;

namespace LeetCode._0698_Partition_to_K_Equal_Sum_Subsets;

[PublicAPI]
public interface ISolution
{
    public bool CanPartitionKSubsets(int[] nums, int k);
}
