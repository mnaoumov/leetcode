namespace LeetCode.Problems._1689_Partitioning_Into_Minimum_Number_Of_Deci_Binary_Numbers;

/// <summary>
/// https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/submissions/1934159849/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinPartitions(string n) => GetDigits(n).Max();
    private static IEnumerable<int> GetDigits(string numStr) => numStr.Select(digitChar => digitChar - '0');
}
