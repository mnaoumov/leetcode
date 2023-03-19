namespace LeetCode._0211_Design_Add_and_Search_Words_Data_Structure;

/// <summary>
/// https://leetcode.com/submissions/detail/918379884/
/// </summary>
public class WordDictionary1 : IWordDictionary
{
    private readonly TrieNode _root = new();

    public void AddWord(string word)
    {
        var node = word.Aggregate(_root, (current, letter) => current.GetOrCreate(letter));
        node.HasWord = true;
    }

    public bool Search(string word)
    {
        var queue = new Queue<TrieNode>();
        queue.Enqueue(_root);

        foreach (var letter in word)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                foreach (var childNode in node.GetChildNodes(letter))
                {
                    queue.Enqueue(childNode);
                }
            }

            if (queue.Count == 0)
            {
                return false;
            }
        }

        return queue.Any(node => node.HasWord);
    }

    private class TrieNode
    {
        private readonly Dictionary<char, TrieNode> _childNodes = new();
        public bool HasWord { get; set; }

        public TrieNode GetOrCreate(char letter)
        {
            if (!_childNodes.TryGetValue(letter, out var childNode))
            {
                childNode = _childNodes[letter] = new TrieNode();
            }

            return childNode;
        }

        public IEnumerable<TrieNode> GetChildNodes(char letter) =>
            letter == '.'
                ? _childNodes.Values
                : _childNodes.TryGetValue(letter, out var childNode)
                    ? new[] { childNode }
                    : Enumerable.Empty<TrieNode>();
    }
}
