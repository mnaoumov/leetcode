using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._3106_Lexicographically_Smallest_String_After_Operations_With_Constraint;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-392/submissions/detail/1225332073/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GetSmallestString(string s, int k)
    {
        const int lettersCount = 'z' - 'a' + 1;

        var sb = new StringBuilder(s);

        var i = 0;

        while (k > 0 && i < sb.Length)
        {
            var letter = sb[i];
            var letterIndex = letter - 'a';

            var changedLetterIndex = Math.Max(0, letterIndex - k);

            if (letterIndex + k >= lettersCount)
            {
                changedLetterIndex = 0;
            }

            sb[i] = (char) (changedLetterIndex + 'a');

            var diff = letterIndex - changedLetterIndex;
            diff = Math.Min(diff, lettersCount - diff);
            k -= diff;
            i++;
        }

        return sb.ToString();
    }
}
