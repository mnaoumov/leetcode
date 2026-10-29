namespace LeetCode.Problems._2642_Design_Graph_With_Shortest_Path_Calculator;

[PublicAPI]
public interface IGraph
{
    void AddEdge(int[] edge);
    int ShortestPath(int node1, int node2);
}
