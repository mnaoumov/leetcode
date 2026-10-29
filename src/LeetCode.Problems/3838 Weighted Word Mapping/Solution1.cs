namespace LeetCode.Problems._3838_Weighted_Word_Mapping;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-176/problems/weighted-word-mapping/submissions/1919006454/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string MapWordWeights(string[] words, int[] weights)
    {
        return string.Concat(words.Select(MapToLetter));

        char MapToLetter(string word)
        {
            const int lettersCount = 26;
            const char firstLetter = 'a';
            var wordWeight = word.Select(letter => weights[letter - firstLetter]).Sum();
            var wordWeightNormalized = wordWeight % lettersCount;
            return (char) (firstLetter + (lettersCount - 1 - wordWeightNormalized));
        }
    }
}
