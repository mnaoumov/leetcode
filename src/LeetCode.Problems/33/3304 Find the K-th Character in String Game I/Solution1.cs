using System.Text;

namespace LeetCode.Problems._3304_Find_the_K_th_Character_in_String_Game_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-417/submissions/detail/1405546483/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char KthCharacter(int k)
    {
        var sb = new StringBuilder("a");

        while (sb.Length < k)
        {
            var n = sb.Length;

            for (var i = 0; i < n; i++)
            {
                var letterIndex = sb[i] - 'a';
                var nextLetterIndex = (letterIndex + 1) % 26;
                var nextLetter = (char) ('a' + nextLetterIndex);
                sb.Append(nextLetter);
            }
        }

        return sb[k - 1];
    }
}
