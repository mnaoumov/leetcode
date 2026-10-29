namespace LeetCode.Problems._0916_Word_Subsets;

/// <summary>
/// https://leetcode.com/problems/word-subsets/submissions/1503681995/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        var totalCounts = new Dictionary<char, int>();

        foreach (var word2 in words2)
        {
            var letterCounts2 = LetterCounts(word2);

            foreach (var (letter, count) in letterCounts2)
            {
                totalCounts.TryAdd(letter, 0);
                totalCounts[letter] = Math.Max(totalCounts[letter], count);
            }
        }

        return words1.Where(IsUniversal).ToArray();

        bool IsUniversal(string word1)
        {
            var letterCounts1 = LetterCounts(word1);
            foreach (var (letter, count) in totalCounts)
            {
                if (!letterCounts1.TryGetValue(letter, out var count1) || count1 < count)
                {
                    return false;
                }
            }
            return true;
        }
    }

    private static Dictionary<char, int> LetterCounts(string word) =>
        word.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
}
