namespace LeetCode._0295_Find_Median_from_Data_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/908021635/
/// </summary>
public class MedianFinder2 : IMedianFinder
{
    private readonly PriorityQueue<int, int> _lowerHalfMaxHeap = new();
    private readonly PriorityQueue<int, int> _topHalfMinHeap = new();

    public void AddNum(int num)
    {
        if (_topHalfMinHeap.TryPeek(out var min, out _) && min <= num)
        {
            _topHalfMinHeap.Enqueue(num, num);
        }
        else
        {
            _lowerHalfMaxHeap.Enqueue(num, -num);
        }

        var count = _lowerHalfMaxHeap.Count + _topHalfMinHeap.Count;
        var expectedLowerHalfMaxHeapCount = (count + 1) / 2;

        if (_lowerHalfMaxHeap.Count > expectedLowerHalfMaxHeapCount)
        {
            var num2 = _lowerHalfMaxHeap.Dequeue();
            _topHalfMinHeap.Enqueue(num2, num2);
        }
        else if (_lowerHalfMaxHeap.Count < expectedLowerHalfMaxHeapCount)
        {
            var num2 = _topHalfMinHeap.Dequeue();
            _lowerHalfMaxHeap.Enqueue(num2, -num2);
        }
    }

    public double FindMedian()
    {
        var count = _lowerHalfMaxHeap.Count + _topHalfMinHeap.Count;
        return count % 2 == 1
            ? _lowerHalfMaxHeap.Peek()
            : (_lowerHalfMaxHeap.Peek() + _topHalfMinHeap.Peek()) / 2.0;
    }
}
