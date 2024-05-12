using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0402_Remove_K_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/924497750/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    // ReSharper disable once IdentifierTypo
    public string RemoveKdigits(string num, int k)
    {
        var sb = new StringBuilder(num);

        var i = 0;

        while (i < sb.Length - 1)
        {
            if (sb[i] <= sb[i + 1])
            {
                i++;
            }
            else if (k > 0)
            {
                sb.Remove(i, 1);
                k--;
            }
            else
            {
                break;
            }
        }

        while (sb.Length > 1 && sb[0] == '0')
        {
            sb.Remove(0, 1);
        }

        return sb.ToString();
    }
}
