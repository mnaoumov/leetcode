using JetBrains.Annotations;

namespace LeetCode._0336_Palindrome_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/961430782/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var reversedTrie = new Trie();
        var ans = new List<IList<int>>();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var reversedWord = string.Concat(word.Reverse());
            reversedTrie.Insert(i, reversedWord);
        }

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];

            for (var k = 0; k <= word.Length; k++)
            {
                var prefix = word[..k];
                var suffix = word[k..];

                if (reversedTrie.Search(prefix) is { } j && j != i && IsPalindrome(suffix))
                {
                    ans.Add(new[] { i, j });
                }

                if (k > 0 && reversedTrie.Search(suffix) is { } j2 && j2 != i && IsPalindrome(prefix))
                {
                    ans.Add(new[] { j2, i });
                }
            }

        }

        return ans;
    }

    private static bool IsPalindrome(string str)
    {
        for (var i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[^(i + 1)])
            {
                return false;
            }
        }

        return true;
    }

    private class Trie
    {
        private readonly Node _rootNode = new();

        public void Insert(int index, string word)
        {
            var node = word.Aggregate(_rootNode, (current, letter) => current.GetOrAddLetterNode(letter));
            node.MarkAsEndOfWord(index);
        }

        public int? Search(string word)
        {
            var node = GetPrefixNode(word);
            return node?.WordIndex;
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
            public int? WordIndex { get; private set; }
            private readonly Dictionary<char, Node> _letterNodes = new();
            public Node GetOrAddLetterNode(char letter) => GetLetterNode(letter) ?? (_letterNodes[letter] = new Node());
            public void MarkAsEndOfWord(int index) => WordIndex = index;
            public Node? GetLetterNode(char letter) => _letterNodes.GetValueOrDefault(letter);
        }
    }
}
