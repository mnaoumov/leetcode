using System.Text;

namespace LeetCode.Problems._3723_Maximize_Sum_of_Squares_of_Digits;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-168/problems/maximize-sum-of-squares-of-digits/submissions/1811345876/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public string MaxSumOfSquares(int num, int sum)
    {
        if (num * 9 < sum)
        {
            return "";
        }

        var sb = new StringBuilder();

        for (var i = 0; i < num; i++)
        {
            var digit = Math.Min(9, sum);
            sb.Append((char) (digit + '0'));
            sum -= digit;
        }

        return sb.ToString();
    }
}
