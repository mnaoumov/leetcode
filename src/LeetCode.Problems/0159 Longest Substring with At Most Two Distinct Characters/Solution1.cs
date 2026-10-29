namespace LeetCode.Problems._0159_Longest_Substring_with_At_Most_Two_Distinct_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/870012259/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LengthOfLongestSubstringTwoDistinct(string s)
    {
        var countsMap = new Dictionary<char, int>();
        var result = 0;
        var startIndex = 0;
        var endIndex = 0;

        while (endIndex < s.Length)
        {
            var endLetter = s[endIndex];
            countsMap[endLetter] = countsMap.GetValueOrDefault(endLetter) + 1;

            while (countsMap.Keys.Count > 2)
            {
                var startLetter = s[startIndex];
                countsMap[startLetter]--;

                if (countsMap[startLetter] == 0)
                {
                    countsMap.Remove(startLetter);
                }

                startIndex++;
            }

            result = Math.Max(result, endIndex - startIndex + 1);
            endIndex++;
        }

        return result;
    }
}
