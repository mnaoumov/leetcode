using System.Text;

namespace LeetCode.Problems._2573_Find_the_String_with_LCP;

/// <summary>
/// https://leetcode.com/submissions/detail/901691527/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string FindTheString(int[][] lcp)
    {
        var n = lcp.Length;

        var sb = new StringBuilder { Length = n };

        var minLetter = 'a';

        for (var i = 0; i < n; i++)
        {
            if (lcp[i][i] != n - i)
            {
                return "";
            }

            if (sb[i] != 0)
            {
                continue;
            }

            if (minLetter > 'z')
            {
                return "";
            }

            sb[i] = minLetter;
            minLetter++;

            for (var j = i + 1; j < n; j++)
            {
                if (lcp[i][j] != lcp[j][i])
                {
                    return "";
                }

                if (lcp[i][j] > n - j)
                {
                    return "";
                }

                for (var k = 0; k < lcp[i][j]; k++)
                {
                    if (sb[j + k] == sb[i + k])
                    {
                        continue;
                    }

                    if (sb[j + k] != 0)
                    {
                        return "";
                    }

                    sb[j + k] = sb[i + k];
                }
            }
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (lcp[i][j] != lcp[j][i])
                {
                    return "";
                }

                if (lcp[i][j] > n - j)
                {
                    return "";
                }

                int k;

                for (k = 0; k < lcp[i][j]; k++)
                {
                    if (sb[j + k] != sb[i + k])
                    {
                        return "";
                    }
                }

                k = lcp[i][j];

                if (j + k < n && sb[i + k] == sb[j + k])
                {
                    return "";
                }
            }
        }

        return sb.ToString();
    }
}
