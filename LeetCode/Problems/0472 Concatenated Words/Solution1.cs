using JetBrains.Annotations;

namespace LeetCode.Problems._0472_Concatenated_Words;

/// <summary>
/// https://leetcode.com/submissions/detail/885982567/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var rootTrieNode = new TrieNode();

        foreach (var word in words)
        {
            rootTrieNode.AddWord(word);
        }

        return words.Where(word => CheckWord(word, 0)).ToList();

        bool CheckWord(string word, int startingIndex)
        {
            if (startingIndex == word.Length)
            {
                return true;
            }

            var trieNode = rootTrieNode;

            for (var index = startingIndex; index < word.Length; index++)
            {
                var letter = word[index];

                if (!trieNode.ChildNodes.TryGetValue(letter, out var nextTrieNode))
                {
                    return false;
                }

                trieNode = nextTrieNode;

                if ((startingIndex > 0 || index < word.Length - 1) && trieNode.IsEndOfWord && CheckWord(word, index + 1))
                {
                    return true;
                }
            }

            return false;
        }

    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> ChildNodes { get; } = new();
        public bool IsEndOfWord { get; private set; }

        public void AddWord(string word)
        {
            var trieNode = this;

            foreach (var letter in word)
            {
                trieNode.ChildNodes.TryAdd(letter, new TrieNode());

                trieNode = trieNode.ChildNodes[letter];
            }

            trieNode.IsEndOfWord = true;
        }
    }
}
