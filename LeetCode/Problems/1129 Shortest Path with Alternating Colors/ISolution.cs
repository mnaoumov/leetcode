using JetBrains.Annotations;

namespace LeetCode.Problems._1129_Shortest_Path_with_Alternating_Colors;

[PublicAPI]
public interface ISolution
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges);
}
