namespace LeetCode.Problems._3110_Score_of_a_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-128/submissions/detail/1231217881/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ScoreOfString(string s) =>
        Enumerable.Range(0, s.Length - 1).Select(i => Math.Abs(s[i + 1] - s[i])).Sum();
}
