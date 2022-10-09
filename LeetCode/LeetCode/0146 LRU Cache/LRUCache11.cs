#pragma warning disable CS8602
namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202712344/
/// </summary>
public class LRUCache11 : ILRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, (int value, LinkedListNode<int> node)> _dictionary;
    private readonly LinkedList<int> _list;

    public LRUCache11(int capacity)
    {
        _capacity = capacity;
        _dictionary = new Dictionary<int, (int value, LinkedListNode<int> node)>(capacity);
        _list = new LinkedList<int>();
    }

    public int Get(int key)
    {
        const int notFound = -1;

        if (_dictionary.ContainsKey(key))
        {
            var value = _dictionary[key].value;
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

        if (_dictionary.ContainsKey(key))
        {
            _list.Remove(_dictionary[key].node);
        }
        _dictionary[key] = (value, _list.AddLast(key));
    }
}
