namespace LeetCode.Problems._1910_Remove_All_Occurrences_of_a_Substring;

/// <summary>
/// https://leetcode.com/problems/remove-all-occurrences-of-a-substring/submissions/1538768426/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RemoveOccurrences(string s, string part)
    {
        while (s.Contains(part)) {
            var partStartIndex = s.IndexOf(part, StringComparison.Ordinal);
            s = s[..partStartIndex] + s[(partStartIndex + part.Length)..];
        }
        return s;
    }
}
