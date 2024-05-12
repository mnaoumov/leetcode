using JetBrains.Annotations;

namespace LeetCode.Problems._2642_Design_Graph_With_Shortest_Path_Calculator;

[PublicAPI]
public interface IGraph
{
    public void AddEdge(int[] edge);
    public int ShortestPath(int node1, int node2);
}
