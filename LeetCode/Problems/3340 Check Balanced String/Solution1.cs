namespace LeetCode.Problems._3340_Check_Balanced_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-422/submissions/detail/1441322747/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsBalanced(string num)
    {
        var balance = 0;

        var sign = 1;

        foreach (var digit in num.Select(symbol => symbol - '0'))
        {
            balance += digit * sign;
            sign *= -1;
        }

        return balance == 0;
    }
}
