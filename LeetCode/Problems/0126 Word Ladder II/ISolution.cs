namespace LeetCode.Problems._0126_Word_Ladder_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList);
}
