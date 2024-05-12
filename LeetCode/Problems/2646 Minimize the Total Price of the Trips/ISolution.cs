using JetBrains.Annotations;

namespace LeetCode.Problems._2646_Minimize_the_Total_Price_of_the_Trips;

[PublicAPI]
public interface ISolution
{
    public int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips);
}
