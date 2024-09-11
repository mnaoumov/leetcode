namespace LeetCode.Problems._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/problems/lru-cache/submissions/845449466/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution13 : ISolution
{
    public ILRUCache Create(int capacity) => new LRUCache(capacity);

    private class LRUCache : ILRUCache
    {
        private readonly Dictionary<int, int> _dict;
        private readonly Queue<int> _queue;
        private readonly Dictionary<int, int> _queueCounts;
        private readonly int _capacity;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _dict = new Dictionary<int, int>(capacity);
            _queue = new Queue<int>(capacity);
            _queueCounts = new Dictionary<int, int>(capacity);
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
            if (_queue.Count == _capacity)
            {
                var leastRecentlyUsed = _queue.Dequeue();
                _queueCounts[leastRecentlyUsed]--;

                if (_queueCounts[leastRecentlyUsed] == 0)
                {
                    _queueCounts.Remove(leastRecentlyUsed);
                    _dict.Remove(leastRecentlyUsed);
                }
            }

            _queue.Enqueue(key);

            _queueCounts.TryAdd(key, 0);

            _dict[key] = value;
            _queueCounts[key]++;
        }
    }
}
