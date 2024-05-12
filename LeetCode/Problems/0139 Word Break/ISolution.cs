using JetBrains.Annotations;

namespace LeetCode.Problems._0139_Word_Break;

[PublicAPI]
public interface ISolution
{
    public bool WordBreak(string s, IList<string> wordDict);
}
