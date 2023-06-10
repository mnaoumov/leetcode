using JetBrains.Annotations;

namespace LeetCode._2729_Check_if_The_Number_is_Fascinating;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-106/submissions/detail/968074324/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsFascinating(int n)
    {
        var str = n.ToString() + (2 * n).ToString() + (3 * n).ToString();
        var chars = str.ToHashSet();
        return chars.Count == 9 && !chars.Contains('0');
    }
}
