namespace LeetCode.Problems._0346_Moving_Average_from_Data_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/882824800/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMovingAverage Create(int size) => new MovingAverage(size);

    private class MovingAverage : IMovingAverage
    {
        private readonly int _size;
        private int _sum;
        private readonly Queue<int> _queue = new();

        public MovingAverage(int size) => _size = size;

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
}
