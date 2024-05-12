using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._0642_Design_Search_Autocomplete_System;

/// <summary>
/// https://leetcode.com/submissions/detail/964770089/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IAutocompleteSystem Create(string[] sentences, int[] times) => new AutocompleteSystem(sentences, times);

    private class AutocompleteSystem : IAutocompleteSystem
    {
        private readonly Trie _trie;
        private readonly StringBuilder _queryBuilder = new();
        private Node? _prefixNode;

        public AutocompleteSystem(IReadOnlyList<string> sentences, IReadOnlyList<int> times)
        {
            _trie = new Trie();

            for (var i = 0; i < sentences.Count; i++)
            {
                _trie.Insert(sentences[i], times[i]);
            }

            _prefixNode = _trie.RootNode;
        }
    
        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                _trie.Insert(_queryBuilder.ToString(), 1);
                _queryBuilder.Clear();
                _prefixNode = _trie.RootNode;
                return Array.Empty<string>();
            }

            _prefixNode = _prefixNode?.GetLetterNode(c);
            _queryBuilder.Append(c);

            if (_prefixNode == null)
            {
                return Array.Empty<string>();
            }

            var list = new List<(string sentence, int count)>();

            Backtrack(_prefixNode);

            return list.OrderByDescending(x => x.count).ThenBy(x => x.sentence).Take(3).Select(x => x.sentence)
                .ToArray();

            void Backtrack(Node node)
            {
                if (node.Count is {} count)
                {
                    list.Add((_queryBuilder.ToString(), count));
                }

                foreach (var (letter, letterNode) in node.LetterNodes)
                {
                    _queryBuilder.Append(letter);
                    Backtrack(letterNode);
                    _queryBuilder.Remove(_queryBuilder.Length - 1, 1);
                }
            }
        }

        private class Trie
        {
            public Node RootNode { get; } = new();

            public void Insert(string word, int count)
            {
                var node = word.Aggregate(RootNode, (current, letter) => current.GetOrAddLetterNode(letter));
                node.Count = (node.Count ?? 0) + count;
            }
        }

        private class Node
        {
            public int? Count { get; set; }

            public Dictionary<char, Node> LetterNodes { get; } = new();
            public Node GetOrAddLetterNode(char letter) => GetLetterNode(letter) ?? (LetterNodes[letter] = new Node());
            public Node? GetLetterNode(char letter) => LetterNodes.GetValueOrDefault(letter);
        }
    }
}
