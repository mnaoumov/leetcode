using JetBrains.Annotations;

namespace LeetCode._2828_Check_if_a_String_Is_an_Acronym_of_Words;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-359/submissions/detail/1026261048/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsAcronym(IList<string> words, string s) => s == string.Concat(words.Select(word => word[0]));
}
