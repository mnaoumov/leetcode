namespace LeetCode.Problems._2416_Sum_of_Prefix_Scores_of_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/1402412405/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] SumPrefixScores(string[] words)
    {
        var trie = new Trie();

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        return words.Select(CountAllPrefixScores).ToArray();

        int CountAllPrefixScores(string word)
        {
            var score = 0;

            for (var i = 1; i <= word.Length; i++)
            {
                score += trie.CountWordsStartingWith(word[..i]);
            }

            return score;
        }
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

        private class TrieNode
        {
            public Dictionary<char, TrieNode> ChildNodes { get; } = new();
            public int WordsStartingWithCount { get; set; }
        }
    }

}
