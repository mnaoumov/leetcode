namespace LeetCode.Problems._0336_Palindrome_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/963942790/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var reversedTrie = new Trie();
        var directTrie = new Trie();
        var ans = new List<IList<int>>();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var reversedWord = string.Concat(word.Reverse());
            reversedTrie.Insert(i, reversedWord);
            directTrie.Insert(i, word);
        }

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var reverseNode = reversedTrie.RootNode;

            if (IsPalindrome(word, 0, word.Length - 1) && reverseNode.WordIndex is { } j2 && j2 != i)
            {
                ans.Add(new[] { i, j2 });
                ans.Add(new[] { j2, i });
            }

            for (var k = 0; k < word.Length; k++)
            {
                reverseNode = reverseNode.GetLetterNode(word[k]);

                if (reverseNode == null)
                {
                    break;
                }

                if (reverseNode.WordIndex is {} j && j != i && IsPalindrome(word, k + 1, word.Length - 1))
                {
                    ans.Add(new[] { i, j });
                }
            }

            var directNode = directTrie.RootNode;

            for (var k = word.Length - 1; k >= 1; k--)
            {
                directNode = directNode.GetLetterNode(word[k]);

                if (directNode == null)
                {
                    break;
                }

                if (directNode.WordIndex is { } j && j != i && IsPalindrome(word, 0, k - 1))
                {
                    ans.Add(new[] { j, i });
                }
            }
        }

        return ans;
    }

    private static bool IsPalindrome(string word, int startIndex, int endIndex)
    {
        var i = startIndex;
        var j = endIndex;

        while (i < j)
        {
            if (word[i] != word[j])
            {
                return false;
            }
            i++;
            j--;
        }

        return true;
    }

    private class Trie
    {
        public Node RootNode { get; } = new();

        public void Insert(int index, string word)
        {
            var node = word.Aggregate(RootNode, (current, letter) => current.GetOrAddLetterNode(letter));
            node.MarkAsEndOfWord(index);
        }

        public class Node
        {
            public int? WordIndex { get; private set; }
            private readonly Dictionary<char, Node> _letterNodes = new();
            public Node GetOrAddLetterNode(char letter) => GetLetterNode(letter) ?? (_letterNodes[letter] = new Node());
            public void MarkAsEndOfWord(int index) => WordIndex = index;
            public Node? GetLetterNode(char letter) => _letterNodes.GetValueOrDefault(letter);
        }
    }
}
