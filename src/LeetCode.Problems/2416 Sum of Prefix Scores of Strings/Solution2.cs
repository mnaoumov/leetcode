namespace LeetCode.Problems._2416_Sum_of_Prefix_Scores_of_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/1402415299/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] SumPrefixScores(string[] words)
    {
        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        return words.Select(trie.CountAllPrefixScores).ToArray();
    }

    private class Trie
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
        }

        public int CountAllPrefixScores(string word)
        {
            var node = _root;
            var ans = 0;

            foreach (var letter in word)
            {
                node = node.ChildNodes.GetValueOrDefault(letter);

                if (node == null)
                {
                    break;
                }

                ans += node.WordsStartingWithCount;
            }

            return ans;
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> ChildNodes { get; } = new();
            public int WordsStartingWithCount { get; set; }
        }
    }

}
