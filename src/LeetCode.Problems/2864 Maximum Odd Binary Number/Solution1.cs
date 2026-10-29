namespace LeetCode.Problems._2864_Maximum_Odd_Binary_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/1190168861/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MaximumOddBinaryNumber(string s)
    {
        var n = s.Length;
        var m = s.Count(digit => digit == '1');
        return string.Concat(Enumerable.Repeat('1', m - 1).Concat(Enumerable.Repeat('0', n - m)).Append('1'));
    }
}
