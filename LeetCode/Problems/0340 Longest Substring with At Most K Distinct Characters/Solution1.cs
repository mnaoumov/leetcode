using JetBrains.Annotations;

namespace LeetCode._0340_Longest_Substring_with_At_Most_K_Distinct_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/945289146/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        var counts = new Dictionary<char, int>();

        var startIndex = 0;
        var endIndex = 0;
        var ans = 0;

        while (endIndex < s.Length)
        {
            var letter = s[endIndex];
            counts[letter] = counts.GetValueOrDefault(letter) + 1;

            while (counts.Count > k)
            {
                var oldLetter = s[startIndex];
                counts[oldLetter]--;

                if (counts[oldLetter] == 0)
                {
                    counts.Remove(oldLetter);
                }

                startIndex++;
            }

            ans = Math.Max(ans, endIndex - startIndex + 1);
            endIndex++;
        }

        return ans;
    }
}
