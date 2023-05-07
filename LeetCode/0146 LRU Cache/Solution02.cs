using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200414974/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution02 : ISolution
{
    public ILRUCache Create(int capacity) => new LRUCache(capacity);

    private class LRUCache : ILRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, (int value, int time)> _dictionary;
        private readonly SortedList<int, int> _timeToKeys;
        private int _time;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _dictionary = new Dictionary<int, (int value, int time)>(capacity);
            _timeToKeys = new SortedList<int, int>(capacity);
            _time = 0;
        }

        public int Get(int key)
        {
            const int notFound = -1;

            _time++;

            if (!_dictionary.ContainsKey(key))
            {
                return notFound;
            }

            var (value, time) = _dictionary[key];
            _dictionary[key] = (value, _time);
            _timeToKeys.Remove(time);
            _timeToKeys.Add(_time, key);
            return value;

        }

        public void Put(int key, int value)
        {
            _time++;
            if (!_dictionary.ContainsKey(key) && _dictionary.Keys.Count == _capacity)
            {
                var leastUsedKey = _timeToKeys.Values[0];
                _dictionary.Remove(leastUsedKey);
                _timeToKeys.RemoveAt(0);

            }
            _dictionary[key] = (value, _time);
            _timeToKeys.Add(_time, key);
        }
    }

}
