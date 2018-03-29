﻿namespace LeetCode.Problem005_LongestPalindromicSubstring
{
    /*
    https://leetcode.com/problems/longest-palindromic-substring/description/

    Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.

    Example:

    Input: "babad"

    Output: "bab"

    Note: "aba" is also a valid answer.
 

    Example:

    Input: "cbbd"

    Output: "bb"
    */


    public interface ISolution
    {
        string LongestPalindrome(string s);
    }
}