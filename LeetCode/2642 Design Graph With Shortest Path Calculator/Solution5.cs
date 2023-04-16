using JetBrains.Annotations;

namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// https://leetcode.com/submissions/detail/934237524/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution5 : ISolution
{
    public IGraph Create(int n, int[][] edges)
    {
        return new Graph5(n, edges);
    }
}