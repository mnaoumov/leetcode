using JetBrains.Annotations;

namespace LeetCode.Problems._2858_Minimum_Edge_Reversals_So_Every_Node_Is_Reachable;

[PublicAPI]
public interface ISolution
{
    public int[] MinEdgeReversals(int n, int[][] edges);
}
