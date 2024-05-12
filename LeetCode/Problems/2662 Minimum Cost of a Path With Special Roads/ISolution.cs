using JetBrains.Annotations;

namespace LeetCode.Problems._2662_Minimum_Cost_of_a_Path_With_Special_Roads;

[PublicAPI]
public interface ISolution
{
    public int MinimumCost(int[] start, int[] target, int[][] specialRoads);
}
