﻿namespace LeetCode._005_Longest_Palindromic_Substring;

public class Solution
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