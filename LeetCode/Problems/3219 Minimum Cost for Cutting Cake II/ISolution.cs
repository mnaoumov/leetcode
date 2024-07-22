using JetBrains.Annotations;

namespace LeetCode.Problems._3219_Minimum_Cost_for_Cutting_Cake_II;

[PublicAPI]
public interface ISolution
{
    public long MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut);
}
