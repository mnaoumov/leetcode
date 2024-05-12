using JetBrains.Annotations;

namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

[UsedImplicitly]
public interface ITrie
{
    [UsedImplicitly]
    public void Insert(string word);

    [UsedImplicitly]
    public bool Search(string word);

    [UsedImplicitly]
    public bool StartsWith(string prefix);
}
