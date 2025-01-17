namespace LeetCode.Problems._3407_Substring_Matching_Pattern;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-147/submissions/detail/1497401855/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasMatch(string s, string p)
    {
        var n = s.Length;
        var m = p.Length;

        var parts = p.Split('*');

        var startIndex = s.IndexOf(parts[0], StringComparison.Ordinal);
        var endIndex = s.LastIndexOf(parts[1], StringComparison.Ordinal);

        return startIndex >= 0 && endIndex >= 0 && startIndex + parts[0].Length <= endIndex;
    }
}
