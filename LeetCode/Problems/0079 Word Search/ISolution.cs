using JetBrains.Annotations;

namespace LeetCode.Problems._0079_Word_Search;

[PublicAPI]
public interface ISolution
{
    public bool Exist(char[][] board, string word);
}
