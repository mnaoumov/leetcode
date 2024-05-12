using JetBrains.Annotations;

namespace LeetCode._1160_Find_Words_That_Can_Be_Formed_by_Characters;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCharacters(string[] words, string chars)
    {
        var charsCounts = CountLetters(chars);
        var ans = 0;

        foreach (var word in words)
        {
            var wordLetterCounts = CountLetters(word);
            var isGood = true;

            foreach (var (letter, count) in wordLetterCounts)
            {
                if (charsCounts.GetValueOrDefault(letter) >= count)
                {
                    continue;
                }

                isGood = false;
                break;
            }

            if (isGood)
            {
                ans += word.Length;
            }
        }
        return ans;
    }

    private static Dictionary<char, int> CountLetters(string chars) => chars.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
}
