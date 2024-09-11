using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2214_Minimum_Health_to_Beat_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/875163614/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinimumHealth(int[] damage, int armor)
    {
        var sum = damage.Select(d => (long) d).Sum();
        var max = damage.Where(d => d <= armor).DefaultIfEmpty(0).Max();
        return sum - max + 1;
    }
}
