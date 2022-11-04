using JetBrains.Annotations;

namespace LeetCode._0131_Palindrome_Partitioning;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> Partition(string s);
}
