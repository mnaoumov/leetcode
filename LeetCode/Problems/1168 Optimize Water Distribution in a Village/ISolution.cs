using JetBrains.Annotations;

namespace LeetCode._1168_Optimize_Water_Distribution_in_a_Village;

[PublicAPI]
public interface ISolution
{
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes);
}
