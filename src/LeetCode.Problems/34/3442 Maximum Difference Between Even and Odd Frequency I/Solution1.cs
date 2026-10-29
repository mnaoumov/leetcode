namespace LeetCode.Problems._3442_Maximum_Difference_Between_Even_and_Odd_Frequency_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-435/problems/maximum-difference-between-even-and-odd-frequency-i/submissions/1528096685/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDifference(string s)
    {
        var counts = s.GroupBy(letter => letter).Select(g => g.Count()).ToArray();
        return counts.Where(count => count % 2 == 1).Max() - counts.Where(count => count % 2 == 0).Min();
    }
}
