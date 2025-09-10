namespace LeetCode.Problems._3663_Find_The_Least_Frequent_Digit;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-164/problems/find-the-least-frequent-digit/submissions/1753614964/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetLeastFrequentDigit(int n) =>
        n.ToString()
            .Select(c => c - '0')
            .GroupBy(d => d)
            .ToDictionary(g => g.Key, g => g.Count())
            .OrderBy(kvp => kvp.Value)
            .ThenBy(kvp => kvp.Key)
            .First()
            .Key;
}
