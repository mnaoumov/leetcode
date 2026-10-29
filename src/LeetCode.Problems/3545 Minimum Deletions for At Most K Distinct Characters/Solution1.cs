namespace LeetCode.Problems._3545_Minimum_Deletions_for_At_Most_K_Distinct_Characters;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-449/problems/minimum-deletions-for-at-most-k-distinct-characters/submissions/1630589607/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDeletion(string s, int k) =>
        s.GroupBy(letter => letter).Select(g => g.Count()).OrderByDescending(x => x).Skip(k).Sum();
}
