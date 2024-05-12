using JetBrains.Annotations;

namespace LeetCode.Problems._3123_Find_Edges_in_Shortest_Paths;

[PublicAPI]
public interface ISolution
{
    public bool[] FindAnswer(int n, int[][] edges);
}
