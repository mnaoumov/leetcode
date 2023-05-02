namespace LeetCode._0460_LFU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/887130111/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class LFUCache2 : ILFUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, int> _dict;
    private readonly Dictionary<int, int> _useCounter;
    private readonly PriorityQueue<(int key, int useCount), (int useCount, int timestamp)> _priorityQueue;
    private int _timestamp;

    public LFUCache2(int capacity)
    {
        _capacity = capacity;
        _dict = new Dictionary<int, int>(capacity);
        _useCounter = new Dictionary<int, int>(capacity);
        _priorityQueue = new PriorityQueue<(int key, int useCount), (int useCount, int timestamp)>(capacity);
    }

    public int Get(int key)
    {
        if (!_dict.TryGetValue(key, out var value))
        {
            return -1;
        }

        IncreaseUseCounter(key);
        return value;
    }

    public void Put(int key, int value)
    {
        if (_dict.Count == Math.Max(1, _capacity) && !_dict.ContainsKey(key))
        {
            int lfuKey;
            int lfuUseCount;

            do
            {
                (lfuKey, lfuUseCount) = _priorityQueue.Dequeue();
            } while (_useCounter[lfuKey] != lfuUseCount);

            _dict.Remove(lfuKey);
            _useCounter.Remove(lfuKey);
        }

        _dict[key] = value;
        IncreaseUseCounter(key);
    }

    private void IncreaseUseCounter(int key)
    {
        _useCounter[key] = _useCounter.GetValueOrDefault(key) + 1;
        _priorityQueue.Enqueue((key, _useCounter[key]), (_useCounter[key], _timestamp));
        _timestamp++;
    }
}
