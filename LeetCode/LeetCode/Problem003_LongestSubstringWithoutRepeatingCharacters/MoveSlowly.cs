using System;
using System.Collections.Generic;

namespace LeetCode.Problem003_LongestSubstringWithoutRepeatingCharacters
{
    public class MoveSlowly : ISolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var n = s.Length;
            var i = 0;
            var j = 0;
            var chars = new HashSet<char>();
            var maxLength = 0;
            while (i < n && j < n)
            {
                if (!chars.Contains(s[j]))
                {
                    chars.Add(s[j]);
                    maxLength = Math.Max(maxLength, j - i + 1);
                    j++;
                }
                else
                {
                    chars.Remove(s[i]);
                    i++;
                }
            }

            return maxLength;
        }
    }
}