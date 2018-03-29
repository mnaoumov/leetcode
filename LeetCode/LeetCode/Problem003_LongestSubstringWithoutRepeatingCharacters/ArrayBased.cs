using System;

namespace LeetCode.Problem003_LongestSubstringWithoutRepeatingCharacters
{
    public class ArrayBased : ISolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var charToIndex = new int[char.MaxValue + 1];

            var maxLength = 0;
            int i = 0;
            for (int j = 0; j < s.Length; j++)
            {
                i = Math.Max(i, charToIndex[s[j]]);

                maxLength = Math.Max(maxLength, j - i + 1);
                charToIndex[s[j]] = j + 1;
            }

            return maxLength;
        }
    }
}