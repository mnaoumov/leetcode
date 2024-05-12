using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0032_Longest_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/200409741/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestValidParentheses(string s)
    {
        var result = 0;
        var n = s.Length;
        var longestPrefixes = new int[n + 1];

        for (int i = n - 2; i >= 0; i--)
        {
            const char closeBracket = ')';
            var endOfPreviousLongest = i + 1 + longestPrefixes[i + 1];

            if (s[i] == closeBracket)
            {
                longestPrefixes[i] = 0;
            }
            else if (s[i + 1] == closeBracket)
            {
                longestPrefixes[i] = 2 + longestPrefixes[i + 2];
            }
            else if (endOfPreviousLongest < s.Length && s[endOfPreviousLongest] == closeBracket)
            {
                longestPrefixes[i] = 2 + longestPrefixes[i + 1];
            }
            else
            {
                longestPrefixes[i] = 0;
            }

            result = Math.Max(result, longestPrefixes[i]);
        }

        return result;
    }
}
