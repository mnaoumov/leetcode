namespace LeetCode.Problems._2729_Check_if_The_Number_is_Fascinating;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-106/submissions/detail/968078468/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsFascinating(int n)
    {
        var str = $"{n}{2 * n}{3 * n}";
        var chars = str.ToHashSet();
        return str.Length == 9 && chars.Count == 9 && !chars.Contains('0');
    }
}
