using JetBrains.Annotations;

namespace LeetCode.Problems._3218_Minimum_Cost_for_Cutting_Cake_I;

[PublicAPI]
public interface ISolution
{
    public int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut);
}
