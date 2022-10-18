// ReSharper disable All
#pragma warning disable
namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

/// <summary>
/// https://leetcode.com/submissions/detail/197128931/
/// </summary>
public class Trie1 : ITrie
{
    private readonly Node root = new Node();

    /// <summary>
    /// Initialize your data structure here.
    /// </summary>
    public Trie1()
    {

    }

    /// <summary>
    /// Inserts a word into the trie.
    /// </summary>
    public void Insert(string word)
    {
        var wordNode = GetWordNode(word, createIfMissing: true);
        wordNode.Inserted = true;
    }

    /// <summary>
    /// Returns if the word is in the trie.
    /// </summary>
    public bool Search(string word)
    {
        var wordNode = GetWordNode(word, createIfMissing: false);
        return wordNode != null && wordNode.Inserted;
    }

    /// <summary>
    /// Returns if there is any word in the trie that starts with the given prefix.
    /// </summary>
    public bool StartsWith(string prefix)
    {
        return GetWordNode(prefix, createIfMissing: false) != null;
    }

    private Node GetWordNode(string word, bool createIfMissing)
    {
        var node = root;
        foreach (var letter in word)
        {
            const char firstLetter = 'a';
            var letterIndex = letter - firstLetter;
            var letterNode = node.LetterNodes[letterIndex];

            if (letterNode == null && createIfMissing)
            {
                node.LetterNodes[letterIndex] = letterNode = new Node();
            }

            node = letterNode;
        }

        return node;
    }

    private class Node
    {
        private const int LettersInAlphabet = 26;
        public readonly Node[] LetterNodes = new Node[LettersInAlphabet];
        public bool Inserted { get; set; }
    }
}
