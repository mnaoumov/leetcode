namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

/// <summary>
/// https://leetcode.com/submissions/detail/870830324/
/// </summary>
public class Trie3 : ITrie
{
    private readonly Node _rootNode = new();

    public void Insert(string word)
    {
        var node = word.Aggregate(_rootNode, (current, letter) => current.GetOrAddLetterNode(letter));
        node.MarkAsEndOfWord();
    }

    public bool Search(string word)
    {
        var node = GetPrefixNode(word);
        return node is { IsEndOfWord: true };
    }

    public bool StartsWith(string prefix)
    {
        var node = GetPrefixNode(prefix);
        return node != null;
    }

    private Node? GetPrefixNode(string prefix)
    {
        var node = _rootNode;

        foreach (var letter in prefix)
        {
            node = node.GetLetterNode(letter);

            if (node == null)
            {
                return null;
            }
        }

        return node;
    }

    private class Node
    {
        private readonly Dictionary<char, Node> _letterNodes = new();

        public Node GetOrAddLetterNode(char letter) => GetLetterNode(letter) ?? (_letterNodes[letter] = new Node());

        public void MarkAsEndOfWord() => IsEndOfWord = true;

        public bool IsEndOfWord { get; private set; }

        public Node? GetLetterNode(char letter) => _letterNodes.TryGetValue(letter, out var letterNode) ? letterNode : null;
    }
}
