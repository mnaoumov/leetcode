using JetBrains.Annotations;

namespace LeetCode.Problems._2473_Minimum_Cost_to_Buy_Apples;

[PublicAPI]
public interface ISolution
{
    public long[] MinCost(int n, int[][] roads, int[] appleCost, int k);
}
