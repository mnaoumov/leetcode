
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0005_Longest_Palindromic_Substring;

/// <summary>
/// https://leetcode.com/submissions/detail/807296429/
/// </summary>
[UsedImplicitly]
public class Solution9 : ISolution
{
    public string LongestPalindrome(string s)
    {
        var n = s.Length;
        var result = "";

        for (var m = 0; m <= 2 * n - 2; m++)
        {
            var maxPossibleLength = m < n ? m + 1 : 2 * n - m;

            if (maxPossibleLength <= result.Length)
            {
                continue;
            }

            for (int i = m / 2; i >= 0; i--)
            {
                var j = m - i;

                if (j >= n)
                {
                    break;
                }

                if (s[i] != s[j])
                {
                    break;
                }

                var palindromeLength = j - i + 1;

                if (palindromeLength > result.Length)
                {
                    result = s.Substring(i, palindromeLength);
                }
            }
        }

        return result;
    }
}
