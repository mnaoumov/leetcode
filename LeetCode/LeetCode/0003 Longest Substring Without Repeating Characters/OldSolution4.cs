namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/198407882/
/// </summary>
public class OldSolution4 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s == "")
        {
            return 0;
        }

        var result = 1;
        var previousMaxSuffixLength = 1;
        for (int i = s.Length - 2; i >= 0; i--)
        {
            int maxSuffixLength = 1;

            while (maxSuffixLength <= previousMaxSuffixLength && s[i] != s[i + maxSuffixLength])
            {
                maxSuffixLength++;
            }

            previousMaxSuffixLength = maxSuffixLength;
            result = Math.Max(result, maxSuffixLength);
        }
        return result;
    }
}