namespace LeetCode.Problems._3931_Check_Adjacent_Digit_Differences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-502/problems/check-adjacent-digit-differences/submissions/2005023103/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsAdjacentDiffAtMostTwo(string s)
    {
        var n = s.Length;
        for (var i =0; i < n - 1; i++)
        {
            var digit1 = s[i] - '0';
            var digit2 = s[i + 1] - '0';

            if (Math.Abs(digit1 - digit2) > 2)
            {
                return false;
            }
        }

        return true;
    }
}
