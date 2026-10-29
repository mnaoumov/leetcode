namespace LeetCode.Problems._3223_Minimum_Length_of_String_After_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1507773122/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumLength(string s) => s.GroupBy(letter => letter).Select(g => g.Count()).Select(count => count % 2 == 0 ? 2 : 1).Sum();
}
