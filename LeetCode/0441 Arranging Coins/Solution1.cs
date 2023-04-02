using JetBrains.Annotations;

namespace LeetCode._0441_Arranging_Coins;

/// <summary>
/// https://leetcode.com/submissions/detail/926837263/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ArrangeCoins(int n) => (int) ((Math.Sqrt(1 + 8 * n) - 1) / 2);
}
