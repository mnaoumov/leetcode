using JetBrains.Annotations;

namespace LeetCode._0212_Word_Search_II;

[PublicAPI]
public interface ISolution
{
    public IList<string> FindWords(char[][] board, string[] words);
}
