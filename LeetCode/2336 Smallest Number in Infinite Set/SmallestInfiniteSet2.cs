namespace LeetCode._2336_Smallest_Number_in_Infinite_Set;

/// <summary>
/// https://leetcode.com/submissions/detail/908120671/
/// </summary>
public class SmallestInfiniteSet2 : ISmallestInfiniteSet
{
    private readonly PriorityQueue<int, int> _heap = new();
    private int _restRangeStart = 1;
    private readonly HashSet<int> _set = new();

    public int PopSmallest()
    {
        if (_heap.TryDequeue(out var num, out _))
        {
            _set.Remove(num);
            return num;
        }

        var result = _restRangeStart;
        _restRangeStart++;
        return result;
    }

    public void AddBack(int num)
    {
        if (num < _restRangeStart && _set.Add(num))
        {
            _heap.Enqueue(num, num);
        }
    }
}
