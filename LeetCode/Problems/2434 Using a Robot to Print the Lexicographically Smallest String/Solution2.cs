using System.Text;
using JetBrains.Annotations;

namespace LeetCode._2434_Using_a_Robot_to_Print_the_Lexicographically_Smallest_String;

/// <summary>
/// https://leetcode.com/submissions/detail/890397591/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public string RobotWithString(string s)
    {
        var letterLastIndexMap = s.Select((letter, index) => (letter, index)).GroupBy(x => x.letter, x => x.index)
            .ToDictionary(g => g.Key, g => g.Max());

        var orderedLetters = letterLastIndexMap.Keys.OrderBy(x => x).ToArray();

        var resultBuilder = new StringBuilder();
        var skippedLettersBuilder = new StringBuilder();
        var minLetterIndex = 0;
        var minLetter = orderedLetters[minLetterIndex];
        var lastIndex = letterLastIndexMap[minLetter];

        for (var i = 0; i < s.Length; i++)
        {
            while (i > lastIndex)
            {
                minLetterIndex++;
                minLetter = orderedLetters[minLetterIndex];
                lastIndex = letterLastIndexMap[minLetter];
            }

            while (skippedLettersBuilder.Length > 0 && skippedLettersBuilder[^1] <= minLetter)
            {
                resultBuilder.Append(skippedLettersBuilder[^1]);
                skippedLettersBuilder.Remove(skippedLettersBuilder.Length - 1, 1);
            }

            if (s[i] == minLetter)
            {
                resultBuilder.Append(minLetter);
            }
            else
            {
                skippedLettersBuilder.Append(s[i]);
            }
        }

        while (skippedLettersBuilder.Length > 0)
        {
            resultBuilder.Append(skippedLettersBuilder[^1]);
            skippedLettersBuilder.Remove(skippedLettersBuilder.Length - 1, 1);
        }

        return resultBuilder.ToString();
    }
}
