using System.Text;

namespace LeetCode.Problems._0402_Remove_K_Digits;

/// <summary>
/// https://leetcode.com/submissions/detail/924501320/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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

                if (i > 0)
                {
                    i--;
                }
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

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
