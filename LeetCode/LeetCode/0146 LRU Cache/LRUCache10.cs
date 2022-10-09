#pragma warning disable CS8602
namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202711086/
/// </summary>
public class LRUCache10 : ILRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, int> _dictionary;
    private readonly LinkedList<int> _list;

    public LRUCache10(int capacity)
    {
        _capacity = capacity;
        _dictionary = new Dictionary<int, int>(capacity);
        _list = new LinkedList<int>();
    }

    public int Get(int key)
    {
        const int notFound = -1;

        if (_dictionary.ContainsKey(key))
        {
            var value = _dictionary[key];
            Put(key, value);
            return value;
        }

        return notFound;
    }

    public void Put(int key, int value)
    {
        if (!_dictionary.ContainsKey(key) && _dictionary.Keys.Count == _capacity)
        {
            var leastUsedKey = _list.First.Value;
            _dictionary.Remove(leastUsedKey);
            _list.RemoveFirst();
        }

        _dictionary[key] = value;
        _list.Remove(key);
        _list.AddLast(key);
    }
}
