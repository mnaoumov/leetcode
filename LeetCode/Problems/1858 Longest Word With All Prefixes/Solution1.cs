using JetBrains.Annotations;

namespace LeetCode.Problems._1858_Longest_Word_With_All_Prefixes;

/// <summary>
/// https://leetcode.com/submissions/detail/959361222/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LongestWord(string[] words)
    {
        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        var ans = "";
        Dfs(trie.RootNode, "");
        return ans;

        void Dfs(Node node, string word)
        {
            if (word.Length > ans.Length)
            {
                ans = word;
            }

            foreach (var (letter, childNode) in node.LetterNodes.Where(kvp => kvp.Value.IsEndOfWord).OrderBy(kvp => kvp.Key))
            {
                Dfs(childNode, word + letter);
            }
        }
    }

    private class Trie
    {
        public Node RootNode { get; } = new();

        public void Insert(string word)
        {
            var node = word.Aggregate(RootNode, (current, letter) => current.GetOrAddLetterNode(letter));
            node.MarkAsEndOfWord();
        }
    }

    private class Node
    {
        public Dictionary<char, Node> LetterNodes { get; } = new();
        public Node GetOrAddLetterNode(char letter) => GetLetterNode(letter) ?? (LetterNodes[letter] = new Node());
        public void MarkAsEndOfWord() => IsEndOfWord = true;
        public bool IsEndOfWord { get; private set; }
        private Node? GetLetterNode(char letter) => LetterNodes.GetValueOrDefault(letter);
    }
}
