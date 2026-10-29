using System.Text;

namespace LeetCode.Problems._2381_Shifting_Letters_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1500109442/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        var n = s.Length;
        var diffs = new int[n];

        foreach (var shift in shifts)
        {
            var start = shift[0];
            var end = shift[1];
            var direction = shift[2];
            var diff = direction == 1 ? 1 : -1;
            diffs[start] += diff;
            if (end + 1 < n)
            {
                diffs[end + 1] -= diff;
            }
        }

        var sb = new StringBuilder(s);
        var totalShift = 0;

        for (var i = 0; i < n; i++)
        {
            var letterIndex = sb[i] - 'a';
            totalShift += diffs[i];
            var newLetterIndex = (letterIndex + totalShift) % 26;
            newLetterIndex = newLetterIndex < 0 ? newLetterIndex + 26 : newLetterIndex;
            sb[i] = (char) ('a' + newLetterIndex);
        }

        return sb.ToString();
    }
}