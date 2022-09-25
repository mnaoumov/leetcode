using System.Text;

namespace LeetCode._014_Longest_Common_Prefix;

public class Solution : ISolution
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