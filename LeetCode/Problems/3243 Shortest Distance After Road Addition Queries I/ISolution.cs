using JetBrains.Annotations;

namespace LeetCode.Problems._3243_Shortest_Distance_After_Road_Addition_Queries_I;

[PublicAPI]
public interface ISolution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries);
}
