using JetBrains.Annotations;

namespace LeetCode.Problems._2045_Second_Minimum_Time_to_Reach_Destination;

[PublicAPI]
public interface ISolution
{
    public int SecondMinimum(int n, int[][] edges, int time, int change);
}
