using System.Text;

namespace LeetCode.Problems._3174_Clear_Digits;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-132/submissions/detail/1281681894/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string ClearDigits(string s)
    {
        var sb = new StringBuilder(s);

        var i = 0;

        while (i < sb.Length)
        {
            if (char.IsDigit(sb[i]))
            {
                sb.Remove(i - 1, 2);
                i--;
            }
            else
            {
                i++;
            }
        }

        return sb.ToString();
    }
}
