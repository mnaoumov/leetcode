namespace LeetCode._2336_Smallest_Number_in_Infinite_Set;

/// <summary>
/// https://leetcode.com/submissions/detail/908108746/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class SmallestInfiniteSet1 : ISmallestInfiniteSet
{
    private readonly PriorityQueue<int, int> _heap = new();
    private int _restRangeStart = 1;

    public int PopSmallest()
    {
        if (_heap.TryDequeue(out var num, out _))
        {
            return num;
        }

        var result = _restRangeStart;
        _restRangeStart++;
        return result;
    }

    public void AddBack(int num)
    {
        if (num < _restRangeStart)
        {
            _heap.Enqueue(num, num);
        }
    }
}
