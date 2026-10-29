namespace LeetCode.Problems._3045_Count_Prefix_and_Suffix_Pairs_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-385/submissions/detail/1178498046/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long CountPrefixSuffixPairs(string[] words)
    {
        var directRoot = new TrieNode();
        var reversedRoot = new TrieNode();

        var directIndexPairs = new HashSet<(int index1, int index2)>();
        var reverseIndexPairs = new HashSet<(int index1, int index2)>();

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            directRoot.Add(word, i, directIndexPairs);

            var reversedWord = string.Concat(word.Reverse());
            reversedRoot.Add(reversedWord, i, reverseIndexPairs);
        }

        directIndexPairs.IntersectWith(reverseIndexPairs);
        return directIndexPairs.Count;
    }

    private class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _childNodes = new();
        private List<int> WordIndices { get; } = new();
        
        public void Add(string word, int wordIndex, ISet<(int index, int index2)> indexPairs)
        {
            var node = this;

            foreach (var letter in word)
            {
                node._childNodes.TryAdd(letter, new TrieNode());
                node = node._childNodes[letter];

                foreach (var previousWordIndex in node.WordIndices)
                {
                    indexPairs.Add((previousWordIndex, wordIndex));
                }
            }

            node.WordIndices.Add(wordIndex);
        }
    }
}
