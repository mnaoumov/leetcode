using System.Text;
using JetBrains.Annotations;

namespace LeetCode._1309_Decrypt_String_from_Alphabet_to_Integer_Mapping;

/// <summary>
/// https://leetcode.com/submissions/detail/927655954/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FreqAlphabets(string s)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
            if (i + 2 < s.Length && s[i + 2] == '#')
            {
                var letterIndex = 10 * ToDigit(i) + ToDigit(i + 1);
                var letter = Letter(letterIndex);
                sb.Append(letter);
                i += 2;
            }
            else
            {
                var letterIndex = ToDigit(i);
                var letter = Letter(letterIndex);
                sb.Append(letter);
            }
        }

        return sb.ToString();

        int ToDigit(int i) => s[i] - '0';
    }

    private static char Letter(int letterIndex) => (char) ('a' + (letterIndex - 1));
}
