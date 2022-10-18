// ReSharper disable All
namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200417348/
/// </summary>
public class LRUCache04 : ILRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, (int value, int time)> _dictionary;
    private readonly SortedDictionary<int, int> _timeToKeys;
    private int _time;

    public LRUCache04(int capacity)
    {
        _capacity = capacity;
        _dictionary = new Dictionary<int, (int value, int time)>(capacity);
        _timeToKeys = new SortedDictionary<int, int>();
        _time = 0;
    }

    public int Get(int key)
    {
        const int notFound = -1;

        _time++;

        if (_dictionary.ContainsKey(key))
        {
            var entry = _dictionary[key];
            _dictionary[key] = (entry.value, _time);
            _timeToKeys.Remove(entry.time);
            _timeToKeys.Add(_time, key);
            return entry.value;
        }

        return notFound;
    }

    public void Put(int key, int value)
    {
        _time++;
        if (!_dictionary.ContainsKey(key) && _dictionary.Keys.Count == _capacity)
        {
            var leastTime = _timeToKeys.Keys.First();
            var leastUsedKey = _timeToKeys[leastTime];
            _dictionary.Remove(leastUsedKey);
            _timeToKeys.Remove(leastTime);

        }
        _dictionary[key] = (value, _time);
        _timeToKeys.Add(_time, key);
    }
}
