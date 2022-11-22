using JetBrains.Annotations;

namespace LeetCode._0151_Reverse_Words_in_a_String;

/// <summary>
/// https://leetcode.com/problems/reverse-words-in-a-string/submissions/843564586/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseWords(string s) => string.Join(" ", s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
}
