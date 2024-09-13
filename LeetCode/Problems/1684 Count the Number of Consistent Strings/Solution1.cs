namespace LeetCode.Problems._1684_Count_the_Number_of_Consistent_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/1387354749/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountConsistentStrings(string allowed, string[] words)
    {
        var allowedLetters = allowed.ToHashSet();
        return words.Count(word => word.All(letter => allowedLetters.Contains(letter)));
    }
}
