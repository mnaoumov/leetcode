using JetBrains.Annotations;

namespace LeetCode.Problems._2481_Minimum_Cuts_to_Divide_a_Circle;

/// <summary>
/// https://leetcode.com/submissions/detail/850235168/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfCuts(int n)
    {
        return n % 2 == 0 ? n / 2 : n;
    }
}
