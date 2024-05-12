using JetBrains.Annotations;

namespace LeetCode._3093_Longest_Common_Suffix_Queries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-390/submissions/detail/1212195786/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        var reverseTrieRoot = new TrieNode();

        var n = wordsContainer.Length;

        foreach (var index in Enumerable.Range(0, n).OrderBy(index => wordsContainer[index].Length))
        {
            var word = wordsContainer[index];
            var reversedWord = string.Concat(word.Reverse());
            reverseTrieRoot.Add(reversedWord, index);
        }

        var m = wordsQuery.Length;

        var ans = new int[m];

        for (var i = 0; i < m; i++)
        {
            var query = wordsQuery[i];
            var reversedQuery = string.Concat(query.Reverse());

            ans[i] = reverseTrieRoot.FindWordIndex(reversedQuery);
        }

        return ans;
    }

    private class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _childNodes = new();
        private int? WordIndex { get; set; }

        public void Add(string word, int index)
        {
            var node = this;
            node.WordIndex ??= index;

            foreach (var letter in word)
            {
                node._childNodes.TryAdd(letter, new TrieNode());
                node = node._childNodes[letter];
                node.WordIndex ??= index;
            }
        }

        public int FindWordIndex(string prefix)
        {
            var node = this;

            foreach (var letter in prefix)
            {
                if (!node._childNodes.TryGetValue(letter, out var node2))
                {
                    break;
                }

                node = node2;
            }

            return (int) node.WordIndex!;
        }
    }
}
