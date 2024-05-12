using JetBrains.Annotations;

namespace LeetCode.Problems._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202712344/
/// </summary>
[UsedImplicitly]
public class Solution11 : ISolution
{
    public ILRUCache Create(int capacity) => new LRUCache(capacity);

    private class LRUCache : ILRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, (int value, LinkedListNode<int> node)> _dictionary;
        private readonly LinkedList<int> _list;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _dictionary = new Dictionary<int, (int value, LinkedListNode<int> node)>(capacity);
            _list = new LinkedList<int>();
        }

        public int Get(int key)
        {
            const int notFound = -1;

            if (!_dictionary.TryGetValue(key, out var value1))
            {
                return notFound;
            }

            var value = value1.value;
            Put(key, value);
            return value;

        }

        public void Put(int key, int value)
        {
            if (!_dictionary.ContainsKey(key) && _dictionary.Keys.Count == _capacity)
            {
                var leastUsedKey = _list.First!.Value;
                _dictionary.Remove(leastUsedKey);
                _list.RemoveFirst();
            }

            if (_dictionary.TryGetValue(key, out var value1))
            {
                _list.Remove(value1.node);
            }
            _dictionary[key] = (value, _list.AddLast(key));
        }
    }

}
