using JetBrains.Annotations;

namespace LeetCode.Problems._3093_Longest_Common_Suffix_Queries;

[PublicAPI]
public interface ISolution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery);
}
