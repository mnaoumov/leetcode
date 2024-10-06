namespace LeetCode.Problems._1813_Sentence_Similarity_III;

/// <summary>
/// https://leetcode.com/submissions/detail/1413857323/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool AreSentencesSimilar(string sentence1, string sentence2)
    {
        var words1 = sentence1.Split(' ');
        var words2 = sentence2.Split(' ');

        var commonPrefixLength = 0;

        var maxPrefixLength = Math.Min(words1.Length, words2.Length);

        for (var i = 0; i < maxPrefixLength; i++)
        {
            var word1 = words1[i];
            var word2 = words2[i];
            if (word1 != word2)
            {
                break;
            }

            commonPrefixLength = i + 1;
        }

        if (commonPrefixLength == 0)
        {
            return false;
        }

        var maxSuffixLength = maxPrefixLength - commonPrefixLength;

        for (var i = 0; i < maxSuffixLength; i++)
        {
            var word1 = words1[^(i + 1)];
            var word2 = words2[^(i + 1)];
            if (word1 != word2)
            {
                return false;
            }
        }

        return true;
    }
}
