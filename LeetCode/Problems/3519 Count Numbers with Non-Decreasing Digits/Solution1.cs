using System.Numerics;
using System.Text;

namespace LeetCode.Problems._3519_Count_Numbers_with_Non_Decreasing_Digits;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-445/problems/count-numbers-with-non-decreasing-digits/submissions/1605223195/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountNumbers(string l, string r, int b) =>
        CountAll(BigInteger.Parse(r), b) - CountAll(BigInteger.Parse(l) - 1, b);

    private static int CountAll(BigInteger maxNum, int numberBase)
    {
        var maxNumBaseStr = ToBaseStr(maxNum, numberBase);
        return CountAll2(maxNumBaseStr, numberBase, 0);
    }

    private static int CountAll2(string maxNumBaseStr, int numberBase, int minDigit)
    {
        var ans = 0;

        if (maxNumBaseStr == "")
        {
            return 1;
        }

        var firstDigit = maxNumBaseStr[0] - '0';
        var maxDigit = (char) ('0' + (numberBase - 1));


        for (var digit = minDigit; digit < numberBase; digit++)
        {
            string nextMaxNumBaseStr;
            if (digit < firstDigit)
            {
                nextMaxNumBaseStr = new string(maxDigit, maxNumBaseStr.Length - 1);
            }
            else if (digit == firstDigit)
            {
                nextMaxNumBaseStr = maxNumBaseStr[1..];
            }
            else
            {
                break;
            }

            ans += CountAll2(nextMaxNumBaseStr, numberBase, digit);
        }

        return ans;
    }

    private static string ToBaseStr(BigInteger num, int numberBase)
    {
        var sb = new StringBuilder();

        while (num > 0)
        {
            var digit = (int) (num % numberBase);
            sb.Insert(0, digit);
            num /= numberBase;
        }

        return sb.ToString();
    }
}
