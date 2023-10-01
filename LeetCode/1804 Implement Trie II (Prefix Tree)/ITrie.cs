using JetBrains.Annotations;

namespace LeetCode._1804_Implement_Trie_II__Prefix_Tree_;

[PublicAPI]
public interface ITrie
{
    public void Insert(string word);
    public int CountWordsEqualTo(string word);
    public int CountWordsStartingWith(string prefix);
    public void Erase(string word);
}
