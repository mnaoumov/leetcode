using System.Text;

namespace LeetCode.Problems._3754_Concatenate_Non_Zero_Digits_and_Multiply_by_Sum_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-477/problems/concatenate-non-zero-digits-and-multiply-by-sum-i/submissions/1837251469/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long SumAndMultiply(int n)
    {
        var sb = new StringBuilder();
        var sum = 0;

        foreach (var symbol in n.ToString().Where(symbol => symbol != '0'))
        {
            sb.Append(symbol);
            sum += symbol - '0';
        }

        if (sb.Length == 0)
        {
            sb.Append('0');
        }

        var m = int.Parse(sb.ToString());
        return 1L * m * sum;
    }
}
