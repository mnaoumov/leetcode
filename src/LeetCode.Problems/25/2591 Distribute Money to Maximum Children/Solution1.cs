namespace LeetCode.Problems._2591_Distribute_Money_to_Maximum_Children;

/// <seealso href="https://leetcode.com/contest/biweekly-contest-100/submissions/detail/917446511/"/>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int DistMoney(int money, int children) => money < children ? -1 : money % 8 == 4 ? money / 8 - 1 : money / 8;
}
