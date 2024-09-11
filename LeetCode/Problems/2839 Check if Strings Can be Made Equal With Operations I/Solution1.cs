namespace LeetCode.Problems._2839_Check_if_Strings_Can_be_Made_Equal_With_Operations_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-112/submissions/detail/1038494916/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanBeEqual(string s1, string s2) =>
        (s1[0] == s2[0] && s1[2] == s2[2] || s1[0] == s2[2] && s1[2] == s2[0]) &&
        (s1[1] == s2[1] && s1[3] == s2[3] || s1[1] == s2[3] && s1[3] == s2[1]);
}
