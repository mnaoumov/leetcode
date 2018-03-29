using System;
using System.Collections.Generic;

namespace LeetCode.Problem003_LongestSubstringWithoutRepeatingCharacters
{
    public class BruteForce : ISolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var chars = new HashSet<char>();
                for (int j = i; j < s.Length; j++)
                {
                    if (chars.Add(s[j]))
                        maxLength = Math.Max(maxLength, j - i + 1);
                    else
                        break;
                }
            }

            return maxLength;
        }
    }
}