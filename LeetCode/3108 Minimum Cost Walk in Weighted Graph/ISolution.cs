using JetBrains.Annotations;

namespace LeetCode._3108_Minimum_Cost_Walk_in_Weighted_Graph;

[PublicAPI]
public interface ISolution
{
    public int[] MinimumCost(int n, int[][] edges, int[][] query);
}
