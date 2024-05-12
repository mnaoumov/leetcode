using JetBrains.Annotations;

namespace LeetCode.Problems._1804_Implement_Trie_II__Prefix_Tree_;

/// <summary>
/// https://leetcode.com/submissions/detail/1063532690/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ITrie Create() => new Trie();

    private class Trie : ITrie
    {
        private readonly TrieNode _root = new();

        public void Insert(string word)
        {
            var node = _root;

            foreach (var letter in word)
            {
                node.ChildNodes.TryAdd(letter, new TrieNode());
                node = node.ChildNodes[letter];
                node.WordsStartingWithCount++;
            }

            node.WordsEqualToCount++;
        }
    
        public int CountWordsEqualTo(string word)
        {
            var node = _root;

            foreach (var letter in word)
            {
                node = node.ChildNodes.GetValueOrDefault(letter);

                if (node == null)
                {
                    return 0;
                }
            }

            return node.WordsEqualToCount;
        }
    
        public int CountWordsStartingWith(string prefix)
        {
            var node = _root;

            foreach (var letter in prefix)
            {
                node = node.ChildNodes.GetValueOrDefault(letter);

                if (node == null)
                {
                    return 0;
                }
            }

            return node.WordsStartingWithCount;
        }
    
        public void Erase(string word)
        {
            var count = CountWordsStartingWith(word);

            if (count == 0)
            {
                return;
            }

            var node = _root;

            foreach (var letter in word)
            {
                node = node.ChildNodes[letter];
                node.WordsStartingWithCount--;
            }

            if (node.WordsEqualToCount > 0)
            {
                node.WordsEqualToCount--;
            }
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> ChildNodes { get; }= new();
            public int WordsEqualToCount { get; set; }
            public int WordsStartingWithCount { get; set; }
        }
    }
}
