namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

public interface ITrie
{
    public void Insert(string word);
    public bool Search(string word);
    public bool StartsWith(string prefix);
}