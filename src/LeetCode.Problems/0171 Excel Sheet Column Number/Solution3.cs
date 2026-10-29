namespace LeetCode.Problems._0171_Excel_Sheet_Column_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/872070189/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int TitleToNumber(string columnTitle) =>
        columnTitle.Aggregate(0, (value, letter) => value * 26 + (letter - 'A') + 1);
}
