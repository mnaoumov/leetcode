namespace LeetCode.Problems._1804_Implement_Trie_II__Prefix_Tree_;

[PublicAPI]
public interface ITrie
{
    void Insert(string word);
    int CountWordsEqualTo(string word);
    int CountWordsStartingWith(string prefix);
    void Erase(string word);
}
