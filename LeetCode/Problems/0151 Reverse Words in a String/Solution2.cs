using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0151_Reverse_Words_in_a_String;

/// <summary>
/// https://leetcode.com/problems/reverse-words-in-a-string/submissions/848093287/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string ReverseWords(string s)
    {
        var sb = new StringBuilder(s);

        var n = sb.Length;
        var insertIndex = n;

        for (var i = 0; i < n; i++)
        {
            var symbol = sb[i];

            if (symbol != ' ')
            {
                if (insertIndex == n && sb.Length > n)
                {
                    sb.Insert(n, ' ');
                }

                sb.Insert(insertIndex, symbol);
                insertIndex++;
            }
            else
            {
                insertIndex = n;
            }
        }

        sb.Remove(0, n);

        return sb.ToString();
    }
}
