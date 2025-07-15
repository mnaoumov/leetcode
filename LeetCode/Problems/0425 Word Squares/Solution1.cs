using System.Text;

namespace LeetCode.Problems._0425_Word_Squares;

/// <summary>
/// https://leetcode.com/problems/word-squares/submissions/1698186472/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<string>> WordSquares(string[] words)
    {
        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        var length = words[0].Length;

        var list = new List<string>();
        var ans = new List<IList<string>>();

        Run();
        return ans;

        void Run()
        {
            if (list.Count == length)
            {
                ans.Add(list.ToArray());
                return;
            }

            var prefix = new StringBuilder();

            foreach (var word in list)
            {
                prefix.Append(word[list.Count]);
            }

            foreach (var word in trie.GetAllPrefixedWords(prefix.ToString()))
            {
                list.Add(word);
                Run();
                list.RemoveAt(list.Count - 1);
            }
        }
    }

    private class Trie
    {
        private TrieNode Root { get; } = new();

        public void Insert(string word)
        {
            var node = Root;
            foreach (var letter in word)
            {
                if (!node.Children.ContainsKey(letter))
                {
                    node.Children[letter] = new TrieNode();
                }
                node = node.Children[letter];
            }
            node.IsEndOfWord = true;
        }

        private TrieNode? GetPrefixNode(string prefix)
        {
            var node = Root;

            foreach (var letter in prefix)
            {
                if (!node.Children.TryGetValue(letter, out var childNode))
                {
                    return null;
                }

                node = childNode;
            }

            return node;
        }

        public IEnumerable<string> GetAllPrefixedWords(string prefix)
        {
            var prefixNode = GetPrefixNode(prefix);
            return GetAllPrefixedWords(prefixNode, new StringBuilder(prefix));
        }

        private static IEnumerable<string> GetAllPrefixedWords(TrieNode? node, StringBuilder prefix)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.IsEndOfWord)
            {
                yield return prefix.ToString();
            }

            foreach (var (letter, childNode) in node.Children)
            {
                prefix.Append(letter);
                foreach (var word in GetAllPrefixedWords(childNode, prefix))
                {
                    yield return word;
                }

                prefix.Remove(prefix.Length - 1, 1);
            }
        }
    }

    private class TrieNode
    {
        public readonly Dictionary<char, TrieNode> Children = new();
        public bool IsEndOfWord { get; set; }
    }
}
