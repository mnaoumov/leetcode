using JetBrains.Annotations;

namespace LeetCode._6294_Difference_Between_Maximum_and_Minimum_Price_Sum;

[PublicAPI]
public interface ISolution
{
    public long MaxOutput(int n, int[][] edges, int[] price);
}
