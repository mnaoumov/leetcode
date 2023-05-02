using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/198407548/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var result = 1;
        var previousMaxSuffixLength = 1;
        for (int i = s.Length - 2; i >= 0; i--)
        {
            int maxSuffixLength = 1;

            while (maxSuffixLength <= previousMaxSuffixLength && s[i] != s[i + maxSuffixLength])
            {
                maxSuffixLength++;
            }

            previousMaxSuffixLength = maxSuffixLength;
            result = Math.Max(result, maxSuffixLength);
        }
        return result;
    }
}
