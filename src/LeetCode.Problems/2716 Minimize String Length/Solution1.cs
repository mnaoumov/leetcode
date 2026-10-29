namespace LeetCode.Problems._2716_Minimize_String_Length;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-348/submissions/detail/963320611/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimizedStringLength(string s) => s.ToHashSet().Count;
}
