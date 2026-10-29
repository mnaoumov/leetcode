namespace LeetCode.Problems._1967_Number_of_Strings_That_Appear_as_Substrings_in_Word;

/// <summary>
/// https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/submissions/2050603651/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumOfStrings(string[] patterns, string word) => patterns.Count(pattern => word.Contains(pattern, StringComparison.Ordinal));
}
