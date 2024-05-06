using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200573215/
/// </summary>
[UsedImplicitly]
public class Solution08 : ISolution
{
    public ILRUCache Create(int capacity) => new LRUCache(capacity);

    private class LRUCache : ILRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, (int value, int time)> _dictionary;
        private int _time;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _dictionary = new Dictionary<int, (int value, int time)>(capacity);
            _time = 0;
        }

        public int Get(int key)
        {
            const int notFound = -1;

            _time++;

            if (!_dictionary.TryGetValue(key, out var value1))
            {
                return notFound;
            }

            var (value, _) = value1;
            _dictionary[key] = (value, _time);
            return value;

        }

        public void Put(int key, int value)
        {
            _time++;
            if (!_dictionary.ContainsKey(key) && _dictionary.Keys.Count == _capacity)
            {
                var leastAccessTime = int.MaxValue;
                var leastUsedKey = -1;

                foreach (var kvp in _dictionary)
                {
                    var time = kvp.Value.time;
                    if (time >= leastAccessTime)
                    {
                        continue;
                    }

                    leastAccessTime = time;
                    leastUsedKey = kvp.Key;
                }
                _dictionary.Remove(leastUsedKey);
            }
            _dictionary[key] = (value, _time);
        }
    }
}
