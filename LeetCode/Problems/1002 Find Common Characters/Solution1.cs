using JetBrains.Annotations;

namespace LeetCode.Problems._1002_Find_Common_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/1277934076/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> CommonChars(string[] words)
    {
        const int lettersCount = 26;

        var totalCounts = new int[lettersCount];
        Array.Fill(totalCounts, int.MaxValue);

        foreach (var word in words)
        {
            var wordLetterCounts = new int[lettersCount];

            foreach (var letterIndex in word.Select(letter => letter - 'a'))
            {
                wordLetterCounts[letterIndex]++;
            }

            for (var letterIndex = 0; letterIndex < lettersCount; letterIndex++)
            {
                totalCounts[letterIndex] = Math.Min(totalCounts[letterIndex], wordLetterCounts[letterIndex]);
            }
        }

        var ans = new List<string>();

        for (var letterIndex = 0; letterIndex < lettersCount; letterIndex++)
        {
            var letterStr = ((char) (letterIndex + 'a')).ToString();
            for (var i = 0; i < totalCounts[letterIndex]; i++)
            {
                ans.Add(letterStr);
            }
        }

        return ans;
    }
}
