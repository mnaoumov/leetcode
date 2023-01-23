namespace LeetCode._0346_Moving_Average_from_Data_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/882824800/
/// </summary>
public class MovingAverage1 : IMovingAverage
{
    private readonly int _size;
    private int _sum;
    private readonly Queue<int> _queue = new();

    public MovingAverage1(int size)
    {
        _size = size;
    }

    public double Next(int val)
    {
        _sum += val;
        _queue.Enqueue(val);

        if (_queue.Count > _size)
        {
            _sum -= _queue.Dequeue();
        }

        return (double) _sum / _queue.Count;
    }
}
