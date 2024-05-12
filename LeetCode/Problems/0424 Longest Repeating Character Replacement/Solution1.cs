using JetBrains.Annotations;

namespace LeetCode.Problems._0424_Longest_Repeating_Character_Replacement;

/// <summary>
/// https://leetcode.com/submissions/detail/929891805/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CharacterReplacement(string s, int k)
    {
        var result = 0;
        var i = 0;
        var letterCountsMap = new Dictionary<char, int>();

        for (var j = 0; j < s.Length; j++)
        {
            var letter = s[j];
            letterCountsMap[letter] = letterCountsMap.GetValueOrDefault(letter) + 1;
            var maxCount = letterCountsMap.Values.Max();
            var replacementsCount = j - i + 1 - maxCount;

            if (replacementsCount > k)
            {
                letterCountsMap[s[i]]--;
                i++;
            }

            result = Math.Max(result, j - i + 1);
        }

        return result;
    }
}
