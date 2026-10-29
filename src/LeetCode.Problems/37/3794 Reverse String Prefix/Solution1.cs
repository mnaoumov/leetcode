namespace LeetCode.Problems._3794_Reverse_String_Prefix;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-173/problems/reverse-string-prefix/submissions/1873176961/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReversePrefix(string s, int k) => string.Concat(s.Take(k).Reverse().Concat(s.Skip(k)));
}
