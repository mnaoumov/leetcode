namespace LeetCode.Problems._0003_Longest_Substring_Without_Repeating_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/806158953/
/// </summary>
[UsedImplicitly]
public class Solution8 : ISolution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var rangeStartIndex = 0;
        var rangeEndIndex = 0;
        var result = 0;

        var dict = new Dictionary<char, int>();

        while (rangeEndIndex < s.Length)
        {
            var rangeEndSymbol = s[rangeEndIndex];
            if (dict.TryGetValue(rangeEndSymbol, out var rangeEndSymbolPreviousIndex) && rangeEndSymbolPreviousIndex >= rangeStartIndex)
            {
                rangeStartIndex = rangeEndSymbolPreviousIndex + 1;
            }
            else
            {
                result = Math.Max(result, rangeEndIndex - rangeStartIndex + 1);
            }

            dict[rangeEndSymbol] = rangeEndIndex;
            rangeEndIndex++;
        }

        return result;
    }
}
