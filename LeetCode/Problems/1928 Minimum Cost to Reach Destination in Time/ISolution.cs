using JetBrains.Annotations;

namespace LeetCode.Problems._1928_Minimum_Cost_to_Reach_Destination_in_Time;

[PublicAPI]
public interface ISolution
{
    public int MinCost(int maxTime, int[][] edges, int[] passingFees);
}
