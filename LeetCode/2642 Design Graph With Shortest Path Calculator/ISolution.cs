using JetBrains.Annotations;

namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

[PublicAPI]
public interface ISolution
{
    public IGraph Create(int n, int[][] edges);
}
