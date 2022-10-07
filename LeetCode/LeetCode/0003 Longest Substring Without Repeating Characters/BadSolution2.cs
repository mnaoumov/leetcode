﻿namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/147413709/
/// </summary>
public class BadSolution2 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var i = 0;
        int j;
        var result = 0;
        var charIndices = new Dictionary<char, int>();
        for (j = 0; j < s.Length; j++)
        {
            if (!charIndices.ContainsKey(s[j]))
            {
                result = Math.Max(result, j - i + 1);
            }
            else
            {
                i = Math.Max(i, charIndices[s[j]] + 1);
            }

            charIndices[s[j]] = j;
        }

        return result;
    }
}