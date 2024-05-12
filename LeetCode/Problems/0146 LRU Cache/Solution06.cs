using JetBrains.Annotations;

namespace LeetCode.Problems._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200571222/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution06 : ISolution
{
    public ILRUCache Create(int capacity) => new LRUCache(capacity);

    private class LRUCache : ILRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, int> _dictionary;
        private readonly LinkedList<int> _list;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _dictionary = new Dictionary<int, int>(capacity);
            _list = new LinkedList<int>();
        }

        public int Get(int key)
        {
            const int notFound = -1;

            if (!_dictionary.ContainsKey(key))
            {
                return notFound;
            }

            _list.Remove(key);
            _list.AddLast(key);
            return _dictionary[key];

        }

        public void Put(int key, int value)
        {
            if (!_dictionary.ContainsKey(key) && _dictionary.Keys.Count == _capacity)
            {
                var leastUsedKey = _list.First!.Value;
                _dictionary.Remove(leastUsedKey);
                _list.RemoveFirst();
            }

            _dictionary[key] = value;
            _list.AddLast(key);
        }
    }
}
