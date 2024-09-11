using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0208_Implement_Trie__Prefix_Tree_;

/// <summary>
/// https://leetcode.com/submissions/detail/197128931/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ITrie Create() => new Trie();

    private class Trie : ITrie
    {
        private readonly Node _root = new();

        public void Insert(string word)
        {
            var wordNode = GetWordNode(word, createIfMissing: true);
            wordNode!.Inserted = true;
        }

        public bool Search(string word)
        {
            var wordNode = GetWordNode(word, createIfMissing: false);
            return wordNode is { Inserted: true };
        }

        public bool StartsWith(string prefix) => GetWordNode(prefix, createIfMissing: false) != null;

        private Node? GetWordNode(string word, bool createIfMissing)
        {
            var node = _root;
            foreach (var letter in word)
            {
                const char firstLetter = 'a';
                var letterIndex = letter - firstLetter;
                var letterNode = node!.LetterNodes[letterIndex];

                if (letterNode == null && createIfMissing)
                {
                    node.LetterNodes[letterIndex] = letterNode = new Node();
                }

                node = letterNode;
            }

            return node;
        }

        private class Node
        {
            private const int LettersInAlphabet = 26;
            public readonly Node?[] LetterNodes = new Node?[LettersInAlphabet];
            public bool Inserted { get; set; }
        }
    }

}
