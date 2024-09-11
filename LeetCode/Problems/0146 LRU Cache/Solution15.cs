namespace LeetCode.Problems._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/problems/lru-cache/submissions/845501362/
/// </summary>
[UsedImplicitly]
public class Solution15 : ISolution
{
    public ILRUCache Create(int capacity) => new LRUCache(capacity);

    private class LRUCache : ILRUCache
    {
        private readonly Dictionary<int, int> _dict;
        private readonly Queue<(int key, int timestamp)> _queue;
        private readonly Dictionary<int, int> _queueTimestampMap;
        private readonly int _capacity;
        private int _timestamp;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _dict = new Dictionary<int, int>(capacity);
            _queue = new Queue<(int key, int timestamp)>(capacity);
            _queueTimestampMap = new Dictionary<int, int>(capacity);
        }

        public int Get(int key)
        {
            if (!_dict.TryGetValue(key, out var value))
            {
                return -1;
            }

            Put(key, value);
            return value;
        }

        public void Put(int key, int value)
        {
            _timestamp++;

            if (!_queueTimestampMap.ContainsKey(key))
            {
                while (_queueTimestampMap.Count >= _capacity)
                {
                    var (leastRecentlyUsedKey, timestamp) = _queue.Dequeue();

                    if (_queueTimestampMap[leastRecentlyUsedKey] != timestamp)
                    {
                        continue;
                    }

                    _queueTimestampMap.Remove(leastRecentlyUsedKey);
                    _dict.Remove(leastRecentlyUsedKey);
                }
            }

            _queue.Enqueue((key, _timestamp));
            _queueTimestampMap[key] = _timestamp;
            _dict[key] = value;
        }
    }
}
