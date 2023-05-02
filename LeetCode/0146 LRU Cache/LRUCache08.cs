// ReSharper disable All
#pragma warning disable
#pragma warning disable IDE0042
namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200573215/
/// </summary>
public class LRUCache08 : ILRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, (int value, int time)> _dictionary;
    private int _time;

    public LRUCache08(int capacity)
    {
        _capacity = capacity;
        _dictionary = new Dictionary<int, (int value, int time)>(capacity);
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
            return entry.value;
        }

        return notFound;
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
