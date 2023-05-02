using JetBrains.Annotations;

namespace LeetCode._2642_Design_Graph_With_Shortest_Path_Calculator;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934207947/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IGraph Create(int n, int[][] edges)
    {
        return new Graph1(n, edges);
    }
}
