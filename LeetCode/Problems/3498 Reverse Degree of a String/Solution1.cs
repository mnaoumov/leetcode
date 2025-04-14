namespace LeetCode.Problems._3498_Reverse_Degree_of_a_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-153/problems/reverse-degree-of-a-string/submissions/1590104596/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ReverseDegree(string s) => s.Select((letter, index) => (26 - (letter - 'a')) * (index + 1)).Sum();
}
