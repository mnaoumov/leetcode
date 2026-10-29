namespace LeetCode.Problems._1258_Synonymous_Sentences;

[PublicAPI]
public interface ISolution
{
    IList<string> GenerateSentences(IList<IList<string>> synonyms, string text);
}
