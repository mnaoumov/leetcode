using System;
using System.Collections.Generic;

namespace LeetCode.Problem003_LongestSubstringWithoutRepeatingCharacters
{
    public class MoveQuicker : ISolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var charToIndexDict = new Dictionary<char, int>();
            var maxLength = 0;
            int i = 0;
            for (int j = 0; j < s.Length; j++)
            {
                int duplicateIndex;
                if (charToIndexDict.TryGetValue(s[j], out duplicateIndex))
                    i = Math.Max(i, duplicateIndex + 1);

                maxLength = Math.Max(maxLength, j - i + 1);
                charToIndexDict[s[j]] = j;
            }

            return maxLength;
        }
    }
}