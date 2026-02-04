namespace LeetCode.Problems._0208_Implement_Trie__Prefix_Tree_;

[UsedImplicitly]
public interface ITrie
{
    [UsedImplicitly]
    void Insert(string word);

    [UsedImplicitly]
    bool Search(string word);

    [UsedImplicitly]
    bool StartsWith(string prefix);
}
