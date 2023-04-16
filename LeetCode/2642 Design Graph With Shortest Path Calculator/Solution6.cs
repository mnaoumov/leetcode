using JetBrains.Annotations;

namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public IGraph Create(int n, int[][] edges)
    {
        return new Graph6(n, edges);
    }
}