namespace LeetCode.Problems._0151_Reverse_Words_in_a_String;

/// <seealso href="https://leetcode.com/problems/reverse-words-in-a-string/submissions/843564586/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseWords(string s) => string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
}
