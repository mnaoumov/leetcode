using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2509_Cycle_Length_Queries_in_a_Tree;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-324/submissions/detail/861433581/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] CycleLengthQueries(int n, int[][] queries) => queries.Select(Answer).ToArray();

    private static int Answer(int[] query) => GetLevel(query[0]) + GetLevel(query[1]) + 1;

    private static int GetLevel(int n) => (int) Math.Log2(n);
}
