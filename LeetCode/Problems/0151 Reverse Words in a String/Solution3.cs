using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0151_Reverse_Words_in_a_String;

/// <summary>
/// https://leetcode.com/problems/reverse-words-in-a-string/submissions/848191493/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string ReverseWords(string s)
    {
        var sb = new StringBuilder(s);

        var targetIndex = 0;
        var shouldInsertSpace = false;

        for (var i = 0; i < sb.Length; i++)
        {
            if (sb[i] == ' ')
            {
                shouldInsertSpace = targetIndex != 0;
            }
            else
            {
                if (shouldInsertSpace)
                {
                    sb[targetIndex] = ' ';
                    targetIndex++;
                    shouldInsertSpace = false;
                }
                sb[targetIndex] = sb[i];
                targetIndex++;
            }
        }

        sb.Length = targetIndex;

        for (var i = 0; i < sb.Length / 2; i++)
        {
            (sb[i], sb[sb.Length - 1 - i]) = (sb[sb.Length - 1 - i], sb[i]);
        }

        {
            var i = 0;

            while (i < sb.Length)
            {
                var j = i + 1;

                while (j < sb.Length && sb[j] != ' ')
                {
                    j++;
                }

                for (var k = 0; k < (j - i) / 2; k++)
                {
                    (sb[i + k], sb[j - 1 - k]) = (sb[j - 1 - k], sb[i + k]);
                }

                i = j;

                if (i < sb.Length && sb[i] == ' ')
                {
                    i++;
                }
            }
        }

        return sb.ToString();
    }
}
