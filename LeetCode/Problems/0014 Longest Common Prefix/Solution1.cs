using System.Text;

namespace LeetCode.Problems._0014_Longest_Common_Prefix;

/// <summary>
/// https://leetcode.com/submissions/detail/808458986/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < strs[0].Length; i++)
        {
            var symbol = strs[0][i];

            if (strs.All(str => i < str.Length && str[i] == symbol))
            {
                sb.Append(symbol);
            }
            else
            {
                break;
            }
        }

        return sb.ToString();
    }
}
