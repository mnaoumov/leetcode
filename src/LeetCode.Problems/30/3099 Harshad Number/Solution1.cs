namespace LeetCode.Problems._3099_Harshad_Number;

/// <seealso href="https://leetcode.com/contest/weekly-contest-391/submissions/detail/1218741759/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        var digitsSum = 0;

        var temp = x;

        while (temp > 0)
        {
            digitsSum += temp % 10;
            temp /= 10;
        }

        return digitsSum > 0 && x % digitsSum == 0 ? digitsSum : -1;
    }
}
