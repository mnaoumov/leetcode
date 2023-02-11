using JetBrains.Annotations;

namespace LeetCode._0734_Sentence_Similarity;

/// <summary>
/// https://leetcode.com/submissions/detail/890322908/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
    {
        if (sentence1.Length != sentence2.Length)
        {
            return false;
        }

        var similarWordsMap = new Dictionary<string, HashSet<string>>();

        foreach (var pair in similarPairs)
        {
            AddSimilar(pair[0], pair[1]);
            AddSimilar(pair[1], pair[0]);

            void AddSimilar(string word1, string word2)
            {
                if (!similarWordsMap.ContainsKey(word1))
                {
                    similarWordsMap[word1] = new HashSet<string>();
                }

                similarWordsMap[word1].Add(word2);
            }
        }

        return sentence1
            .Zip(sentence2, (word1, word2) => (word1, word2))
            .All(x =>
                x.word1 == x.word2
                || similarWordsMap.TryGetValue(x.word1, out var similarWords)
                && similarWords.Contains(x.word2));
    }
}
