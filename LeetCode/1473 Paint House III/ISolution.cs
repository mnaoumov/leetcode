using JetBrains.Annotations;

namespace LeetCode._1473_Paint_House_III;

[PublicAPI]
public interface ISolution
{
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target);
}
