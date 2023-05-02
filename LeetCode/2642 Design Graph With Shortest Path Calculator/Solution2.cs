using JetBrains.Annotations;

namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934221388/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IGraph Create(int n, int[][] edges)
    {
        return new Graph2(n, edges);
    }
}
