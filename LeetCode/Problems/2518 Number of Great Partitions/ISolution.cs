using JetBrains.Annotations;

namespace LeetCode.Problems._2518_Number_of_Great_Partitions;

[PublicAPI]
public interface ISolution
{
    public int CountPartitions(int[] nums, int k);
}
