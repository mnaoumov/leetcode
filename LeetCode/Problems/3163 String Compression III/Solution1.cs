using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._3163_String_Compression_III;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-399/submissions/detail/1268019933/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string CompressedString(string word)
    {
        var sb = new StringBuilder();

        var lastLetter = word[0];
        var count = 0;

        foreach (var letter in word)
        {
            if (letter == lastLetter && count < 9)
            {
                count++;
            }
            else
            {
                sb.Append(count);
                sb.Append(lastLetter);

                lastLetter = letter;
                count = 1;
            }
        }

        sb.Append(count);
        sb.Append(lastLetter);

        return sb.ToString();
    }
}
