// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class TrieTemplate
{
    public sealed class Trie
    {
        private readonly TrieNode _root = new();

        public void Insert(string word)
        {
            var node = _root;
            node.PrefixCount++;

            foreach (var letter in word)
            {
                if (!node.Children.TryGetValue(letter, out var child))
                {
                    child = new TrieNode();
                    node.Children[letter] = child;
                }

                node = child;
                node.PrefixCount++;
            }

            node.WordCount++;
        }

        /// <summary>Removes one copy of word; false, and nothing changes, when it is not in the trie.</summary>
        public bool Remove(string word)
        {
            if (!Contains(word))
            {
                return false;
            }

            var node = _root;
            node.PrefixCount--;

            foreach (var letter in word)
            {
                var child = node.Children[letter];

                if (--child.PrefixCount == 0)
                {
                    node.Children.Remove(letter);
                }

                node = child;
            }

            node.WordCount--;
            return true;
        }

        public bool Contains(string word) => CountWord(word) > 0;

        public bool StartsWith(string prefix) => CountPrefix(prefix) > 0;

        /// <summary>How many copies of word were inserted.</summary>
        public int CountWord(string word) => Find(word)?.WordCount ?? 0;

        /// <summary>How many inserted words (with copies) start with prefix.</summary>
        public int CountPrefix(string prefix) => Find(prefix)?.PrefixCount ?? 0;

        /// <summary>The node prefix leads to, null when none; walk its Children to search letter by letter.</summary>
        public TrieNode? Find(string prefix)
        {
            var node = _root;

            foreach (var letter in prefix)
            {
                if (!node.Children.TryGetValue(letter, out node))
                {
                    return null;
                }
            }

            return node;
        }

        public TrieNode Root => _root;
    }

    public sealed class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new();
        public int WordCount { get; set; }
        public int PrefixCount { get; set; }
        public bool IsWord => WordCount > 0;
    }
}
