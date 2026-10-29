namespace LeetCode.Problems._0242_Valid_Anagram;

/// <summary>
/// https://leetcode.com/submissions/detail/923049178/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsAnagram(string s, string t)
    {
        var sSortedLetters = s.OrderBy(letter => letter);
        var tSortedLetters = t.OrderBy(letter => letter);
        return sSortedLetters.SequenceEqual(tSortedLetters);
    }
}
