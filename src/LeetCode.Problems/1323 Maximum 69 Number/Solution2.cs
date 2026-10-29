namespace LeetCode.Problems._1323_Maximum_69_Number;

/// <summary>
/// https://leetcode.com/problems/maximum-69-number/submissions/838363666/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int Maximum69Number(int num)
    {
        var tailNum = 0;
        var tailResult = 0;
        var tensPower = 1;

        while (num > 0)
        {
            var digit = num % 10;
            num /= 10;

            if (digit == 6)
            {
                tailResult = tensPower * 9 + tailNum;
            }
            else
            {
                tailResult = tensPower * digit + tailResult;
            }

            tailNum = tensPower * digit + tailNum;
            tensPower *= 10;
        }

        return tailResult;
    }
}
