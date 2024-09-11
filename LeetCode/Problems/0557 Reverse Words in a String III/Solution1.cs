namespace LeetCode.Problems._0557_Reverse_Words_in_a_String_III;

/// <summary>
/// https://leetcode.com/submissions/detail/898884252/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseWords(string s) => string.Join(" ", s.Split(' ').Select(ReverseWord));
    private static string ReverseWord(string word) => string.Concat(word.Reverse());
}
