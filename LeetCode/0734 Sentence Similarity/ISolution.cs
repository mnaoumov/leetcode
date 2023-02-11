using JetBrains.Annotations;

namespace LeetCode._0734_Sentence_Similarity;

[PublicAPI]
public interface ISolution
{
    public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs);
}
