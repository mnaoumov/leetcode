using System.Text;

namespace LeetCode.Problems._0345_Reverse_Vowels_of_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/836406176/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

    public string ReverseVowels(string s)
    {
        var reversedVowels = s.Where(IsVowel).Reverse().ToArray();
        var reversedVowelIndex = 0;

        var sb = new StringBuilder(s);

        for (var i = 0; i < s.Length; i++)
        {
            if (!IsVowel(s[i]))
            {
                continue;
            }

            sb[i] = reversedVowels[reversedVowelIndex];
            reversedVowelIndex++;
        }

        return sb.ToString();
    }

    private static bool IsVowel(char letter)
    {
        return Vowels.Contains(char.ToLower(letter));
    }
}
