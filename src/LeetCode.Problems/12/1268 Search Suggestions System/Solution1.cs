namespace LeetCode.Problems._1268_Search_Suggestions_System;

/// <summary>
/// https://leetcode.com/submissions/detail/921634851/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        var trie = new Trie();

        foreach (var product in products)
        {
            trie.Add(product);
        }

        var prefix = "";

        var result = new List<IList<string>>();

        foreach (var searchLetter in searchWord)
        {
            prefix += searchLetter;
            result.Add(trie.SearchByPrefix(prefix).Take(3).ToArray());
        }

        return result;
    }

    private class Trie
    {
        private Node? _root;

        public void Add(string word) => _root = Add(_root, word, 0);

        private static Node Add(Node? node, string word, int letterIndex)
        {
            node ??= new Node();

            if (letterIndex == word.Length)
            {
                node.HasWord = true;
                return node;
            }

            var letter = word[letterIndex];
            var childNode = node.ChildNodes.GetValueOrDefault(letter);
            node.ChildNodes[letter] = Add(childNode, word, letterIndex + 1);
            return node;
        }

        private class Node
        {
            public readonly SortedDictionary<char, Node> ChildNodes = new();
            public bool HasWord { get; set; }
        }

        public IEnumerable<string> SearchByPrefix(string prefix) => GetWords(NodeByPrefix(prefix), prefix);

        private static IEnumerable<string> GetWords(Node? node, string word)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.HasWord)
            {
                yield return word;
            }

            foreach (var (letter, childNode) in node.ChildNodes)
            {
                foreach (var resultWord in GetWords(childNode, word + letter))
                {
                    yield return resultWord;
                }
            }
        }

        private Node? NodeByPrefix(string prefix)
        {
            var node = _root;
            var prefixIndex = 0;

            while (node != null && prefixIndex < prefix.Length)
            {
                var letter = prefix[prefixIndex];
                var letterNode = node.ChildNodes.GetValueOrDefault(letter);
                node = letterNode;
                prefixIndex++;
            }

            return node;
        }
    }
}
