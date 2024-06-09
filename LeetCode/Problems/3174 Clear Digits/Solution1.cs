using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._3174_Clear_Digits;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-132/submissions/detail/1281668630/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
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
                i -= 2;
            }
            else
            {
                i++;
            }
        }

        return sb.ToString();
    }
}
