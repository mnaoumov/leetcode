using JetBrains.Annotations;

namespace LeetCode._0140_Word_Break_II;

[PublicAPI]
public interface ISolution
{
    public IList<string> WordBreak(string s, IList<string> wordDict);
}
