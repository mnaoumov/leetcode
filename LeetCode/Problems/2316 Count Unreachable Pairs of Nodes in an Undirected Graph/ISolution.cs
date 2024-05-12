using JetBrains.Annotations;

namespace LeetCode.Problems._2316_Count_Unreachable_Pairs_of_Nodes_in_an_Undirected_Graph;

[PublicAPI]
public interface ISolution
{
    public long CountPairs(int n, int[][] edges);
}
