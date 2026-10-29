namespace LeetCode.Problems._3692_Majority_Frequency_Characters;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-166/problems/majority-frequency-characters/submissions/1784276143/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MajorityFrequencyGroup(string s)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var group = counts.GroupBy(kvp => kvp.Value).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).First();
        return string.Concat(group.Select(g => g.Key));
    }
}
