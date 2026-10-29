using System.Text;

namespace LeetCode.Problems._3602_Hexadecimal_and_Hexatrigesimal_Conversion;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-160/problems/hexadecimal-and-hexatrigesimal-conversion/submissions/1687324473/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ConcatHex36(int n) => ToBaseString(n * n, 16) + ToBaseString(n * n * n, 36);

    private static string ToBaseString(int n, int @base)
    {
        var sb = new StringBuilder();

        while (n > 0)
        {
            var remainder = n % @base;
            var lastDigit = remainder < 10
                ? (char) ('0' + remainder)
                : (char) ('A' + remainder - 10);
            sb.Insert(0, lastDigit);
            n /= @base;
        }

        return sb.ToString();
    }
}
