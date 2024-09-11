// ReSharper disable All
#pragma warning disable
namespace LeetCode.Problems._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/147414013/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var i = 0;
        var j = 0;
        var result = 0;
        var charIndices = new Dictionary<char, int>();
        for (j = 0; j < s.Length; j++)
        {
            if (charIndices.ContainsKey(s[j]))
            {
                i = Math.Max(i, charIndices[s[j]] + 1);
            }
            result = Math.Max(result, j - i + 1);
            charIndices[s[j]] = j;
        }

        return result;
    }
}
