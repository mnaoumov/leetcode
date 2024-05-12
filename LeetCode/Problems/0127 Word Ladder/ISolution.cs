using JetBrains.Annotations;

namespace LeetCode._0127_Word_Ladder;

[PublicAPI]
public interface ISolution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList);
}
