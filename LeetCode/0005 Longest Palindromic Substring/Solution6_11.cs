// ReSharper disable All
using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0005_Longest_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/147572986/
/// https://leetcode.com/submissions/detail/815933885/
/// </summary>
//[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution6_11 : ISolution
{
    public string LongestPalindrome(string s)
    {
        var max = "";
        var n = s.Length;
        for (int l = 0; l < 2 * n; l++)
        {
            for (int i = l / 2, j = l - i; i >= 0 && j < n; i--, j++)
            {
                if (s[i] != s[j])
                    break;
                var potentialMax = s.Substring(i, j - i + 1);
                if (max.Length < potentialMax.Length)
                    max = potentialMax;
            }
        }

        return max;
    }
}