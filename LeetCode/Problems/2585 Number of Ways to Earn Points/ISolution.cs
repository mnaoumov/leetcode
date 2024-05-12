using JetBrains.Annotations;

namespace LeetCode.Problems._2585_Number_of_Ways_to_Earn_Points;

[PublicAPI]
public interface ISolution
{
    public int WaysToReachTarget(int target, int[][] types);
}
