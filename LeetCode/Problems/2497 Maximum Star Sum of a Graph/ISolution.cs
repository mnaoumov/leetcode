using JetBrains.Annotations;

namespace LeetCode.Problems._2497_Maximum_Star_Sum_of_a_Graph;

[PublicAPI]
public interface ISolution
{
    public int MaxStarSum(int[] vals, int[][] edges, int k);
}
