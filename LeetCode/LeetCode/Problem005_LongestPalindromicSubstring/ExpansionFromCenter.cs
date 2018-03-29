using System;

namespace LeetCode.Problem005_LongestPalindromicSubstring
{
    public class ExpansionFromCenter : ISolution
    {
        public string LongestPalindrome(string s)
        {
            var max = "";
            var n = s.Length;
            for (int l = 1; l <= 2 * n - 3; l++)
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
}