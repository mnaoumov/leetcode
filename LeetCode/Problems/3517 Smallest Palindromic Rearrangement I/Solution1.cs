using System.Text;

namespace LeetCode.Problems._3517_Smallest_Palindromic_Rearrangement_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-445/problems/smallest-palindromic-rearrangement-i/submissions/1605136073/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SmallestPalindrome(string s)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());

        var sb = new StringBuilder();

        var middleLetter = '\0';
        var index = 0;

        foreach (var letter in counts.Keys.OrderBy(x => x))
        {
            var count = counts[letter];

            if (count % 2 == 1)
            {
                middleLetter = letter;
            }

            sb.Insert(index, letter.ToString(), count / 2 * 2);
            index += count / 2;
        }

        if (middleLetter != '\0')
        {
            sb.Insert(index, middleLetter);
        }

        return sb.ToString();
    }
}
