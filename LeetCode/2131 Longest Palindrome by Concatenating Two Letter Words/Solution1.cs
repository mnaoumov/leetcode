using JetBrains.Annotations;

namespace LeetCode._2131_Longest_Palindrome_by_Concatenating_Two_Letter_Words;

/// <summary>
/// https://leetcode.com/submissions/detail/835714151/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestPalindrome(string[] words)
    {
        var wordCounts = words.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        var result = 0;

        var processedWords = new HashSet<string>();
        var hasOddCountedTwoLettersPalindrome = false;

        foreach (var word in wordCounts.Keys.Where(word => !processedWords.Contains(word)))
        {
            processedWords.Add(word);
            if (word[0] == word[1])
            {
                result += wordCounts[word] / 2 * 4;

                if (wordCounts[word] % 2 == 1)
                {
                    hasOddCountedTwoLettersPalindrome = true;
                }
            }
            else
            {
                var reversedWord = new string(new[] { word[1], word[0] });
                processedWords.Add(reversedWord);

                if (wordCounts.ContainsKey(reversedWord))
                {
                    result += Math.Min(wordCounts[word], wordCounts[reversedWord]) * 4;
                }
            }
        }

        if (hasOddCountedTwoLettersPalindrome)
        {
            result += 2;
        }

        return result;
    }
}
