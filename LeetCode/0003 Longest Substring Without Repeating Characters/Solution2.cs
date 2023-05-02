using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/147412060/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var i = 0;
        var j = 0;
        var result = 0;
        var chars = new HashSet<char>();
        while (i < s.Length && j < s.Length)
        {
            if (!chars.Contains(s[j]))
            {
                chars.Add(s[j]);
                result = Math.Max(result, j - i + 1);
                j++;
            }
            else
            {
                chars.Remove(s[i]);
                i++;
            }
        }

        return result;
    }
}
