using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2785_Sort_Vowels_in_a_String;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-109/submissions/detail/1000999371/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SortVowels(string s)
    {
        var sb = new StringBuilder
        {
            Length = s.Length
        };

        var possibleVowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        var vowels = new List<char>();
        var vowelPositions = new List<int>();

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];

            if (possibleVowels.Contains(char.ToLower(letter)))
            {
                vowels.Add(letter);
                vowelPositions.Add(i);
            }
            else
            {
                sb[i] = letter;
            }
        }

        vowels.Sort();

        foreach (var (vowelPosition, vowel) in vowelPositions.Zip(vowels, (vowelPosition, vowel) => (vowelPosition, vowel)))
        {
            sb[vowelPosition] = vowel;
        }

        return sb.ToString();
    }
}
