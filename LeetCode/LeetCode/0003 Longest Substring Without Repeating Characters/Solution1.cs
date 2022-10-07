namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/147406086/
/// </summary>
public class Solution1 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;
        var max = 1;
        for (int i = 0; i < s.Length; i++)
        {
            var letters = new HashSet<char>();
            var length = 1;
            letters.Add(s[i]);
            for (int j = i + 1; j < s.Length; j++)
            {
                if (letters.Add(s[j]))
                {
                    length++;
                    if (length > max)
                        max = length;
                }
                else
                    break;
            }
        }

        return max;
    }
}