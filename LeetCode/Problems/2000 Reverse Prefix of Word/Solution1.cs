using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._2000_Reverse_Prefix_of_Word;

/// <summary>
/// https://leetcode.com/submissions/detail/898892979/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReversePrefix(string word, char ch)
    {
        var i = 0;
        int j;

        for (j = 0; j < word.Length; j++)
        {
            if (word[j] == ch)
            {
                break;
            }
        }

        if (j == word.Length)
        {
            return word;
        }

        var sb = new StringBuilder(word);

        while (i < j)
        {
            (sb[i], sb[j]) = (sb[j], sb[i]);
            i++;
            j--;
        }

        return sb.ToString();
    }
}
