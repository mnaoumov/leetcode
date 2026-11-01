namespace LeetCode.Problems._0441_Arranging_Coins;

/// <seealso href="https://leetcode.com/submissions/detail/926837263/"/>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ArrangeCoins(int n) => (int) ((Math.Sqrt(1 + 8 * n) - 1) / 2);
}
