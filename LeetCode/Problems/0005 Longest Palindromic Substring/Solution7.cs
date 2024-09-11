
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0005_Longest_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/147577534/
/// </summary>
[UsedImplicitly]
public class Solution7 : ISolution
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;
        var max = "";
        var n = s.Length;
        var palindromeSubstringChecksTable = new bool[n, n];

        for (int d = 0; d < n; d++)
        {
            for (int i = 0; i < n - d; i++)
            {
                var j = i + d;
                var isPalindrome = s[i] == s[j] && (d < 2 || palindromeSubstringChecksTable[i + 1, j - 1]);
                palindromeSubstringChecksTable[i, i + d] = isPalindrome;

                if (max.Length < d + 1 && isPalindrome)
                    max = s.Substring(i, d + 1);
            }
        }

        return max;
    }
}
