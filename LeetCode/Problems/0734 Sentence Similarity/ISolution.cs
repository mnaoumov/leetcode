namespace LeetCode.Problems._0734_Sentence_Similarity;

[PublicAPI]
public interface ISolution
{
    bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs);
}
