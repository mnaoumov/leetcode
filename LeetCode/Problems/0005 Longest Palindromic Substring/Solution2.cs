using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0005_Longest_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/147423828/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string LongestPalindrome(string s)
    {
        var max = "";
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                var sub = s.Substring(i, j - i + 1);
                if (sub.Length > max.Length && IsPalindrome(sub))
                {
                    max = sub;
                }
            }
        }

        return max;
    }

    bool IsPalindrome(string s)
    {
        for (int i = 0; i <= (s.Length - 1) / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }
}
