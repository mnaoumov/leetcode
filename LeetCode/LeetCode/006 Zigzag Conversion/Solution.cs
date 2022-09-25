﻿using System.Text;

namespace LeetCode._006_Zigzag_Conversion;

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }
        
        var period = 2 * numRows - 2;
        var sb = new StringBuilder();

        for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
        {
            var firstCharIndex = rowIndex;
            var secondCharIndex = period - rowIndex;
            var shouldUseSecondCharIndex = firstCharIndex < secondCharIndex && secondCharIndex < period;

            while (true)
            {
                if (!TryAddChar(sb, s, firstCharIndex) || shouldUseSecondCharIndex && !TryAddChar(sb, s, secondCharIndex))
                {
                    break;
                }

                firstCharIndex += period;
                secondCharIndex += period;
            }
        }

        return sb.ToString();
    }

    private static bool TryAddChar(StringBuilder sb, string s, int index)
    {
        if (index >= s.Length)
        {
            return false;
        }

        sb.Append(s[index]);
        return true;
    }
}