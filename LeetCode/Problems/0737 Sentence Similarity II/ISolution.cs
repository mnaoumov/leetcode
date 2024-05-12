using JetBrains.Annotations;

namespace LeetCode.Problems._0737_Sentence_Similarity_II;

[PublicAPI]
public interface ISolution
{
    public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs);
}
