namespace LeetCode.Problems._2729_Check_if_The_Number_is_Fascinating;

/// <seealso href="https://leetcode.com/contest/biweekly-contest-106/submissions/detail/968074324/">Submission</seealso>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsFascinating(int n)
    {
        var str = $"{n}{2 * n}{3 * n}";
        var chars = str.ToHashSet();
        return chars.Count == 9 && !chars.Contains('0');
    }
}
