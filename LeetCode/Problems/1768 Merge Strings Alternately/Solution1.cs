using System.Text;

namespace LeetCode.Problems._1768_Merge_Strings_Alternately;

/// <summary>
/// https://leetcode.com/submissions/detail/927547666/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MergeAlternately(string word1, string word2)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < Math.Max(word1.Length, word2.Length); i++)
        {
            if (i < word1.Length)
            {
                sb.Append(word1[i]);
            }

            if (i < word2.Length)
            {
                sb.Append(word2[i]);
            }
        }

        return sb.ToString();
    }
}
