using System.Text;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0402_Remove_K_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/924499788/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    // ReSharper disable once IdentifierTypo
    public string RemoveKdigits(string num, int k)
    {
        var sb = new StringBuilder(num);

        var i = 0;

        while (i < sb.Length)
        {
            if (i + 1 < sb.Length && sb[i] <= sb[i + 1])
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

        if (k > 0)
        {
            sb.Remove(sb.Length - k, k);
        }

        while (sb.Length > 1 && sb[0] == '0')
        {
            sb.Remove(0, 1);
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
