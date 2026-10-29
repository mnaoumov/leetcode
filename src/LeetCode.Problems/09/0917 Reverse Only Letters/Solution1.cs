using System.Text;

namespace LeetCode.Problems._0917_Reverse_Only_Letters;

/// <summary>
/// https://leetcode.com/submissions/detail/898888007/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReverseOnlyLetters(string s)
    {
        var sb = new StringBuilder(s);

        var i = 0;
        var j = s.Length - 1;

        while (i < j)
        {
            while (i < j && !IsEnglishLetter(s[i]))
            {
                i++;
            }

            while (i < j && !IsEnglishLetter(s[j]))
            {
                j--;
            }

            if (i == j)
            {
                break;
            }

            (sb[i], sb[j]) = (sb[j], sb[i]);
            i++;
            j--;
        }

        return sb.ToString();
    }

    private static bool IsEnglishLetter(char symbol) => symbol is >= 'A' and <= 'Z' or >= 'a' and <= 'z';
}
