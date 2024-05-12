using JetBrains.Annotations;

namespace LeetCode.Problems._3121_Count_the_Number_of_Special_Characters_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-394/submissions/detail/1237800188/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSpecialChars(string word)
    {
        var maxLowerIndices = new Dictionary<char, int>();
        var minUpperIndices = new Dictionary<char, int>();

        for (var index = 0; index < word.Length; index++)
        {
            var letter = word[index];

            if (char.IsLower(letter))
            {
                maxLowerIndices[letter] = index;
            }
            else
            {
                var lower = char.ToLower(letter);
                minUpperIndices.TryAdd(lower, index);
            }
        }

        return maxLowerIndices.Keys.Count(letter =>
            maxLowerIndices[letter] < minUpperIndices.GetValueOrDefault(letter, -1));
    }
}
