using System.Text;

namespace LeetCode.Problems._3561_Resulting_String_After_Adjacent_Removals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-451/problems/resulting-string-after-adjacent-removals/submissions/1643610952/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ResultingString(string s)
    {
        var sb = new StringBuilder(s);

        var resultIndex = 0;

        while (resultIndex < sb.Length - 1)
        {
            var letterIndex = sb[resultIndex] - 'a';
            var nextLetterIndex = sb[resultIndex + 1] - 'a';
            var diff = Math.Abs(letterIndex-nextLetterIndex);

            if (diff is not (1 or 25))
            {
                resultIndex++;
                continue;
            }

            sb.Remove(resultIndex, 2);
            resultIndex = Math.Max(0, resultIndex - 1);
        }

        return sb.ToString();
    }
}
