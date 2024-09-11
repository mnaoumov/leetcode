namespace LeetCode.Problems._0933_Number_of_Recent_Calls;

/// <summary>
/// https://leetcode.com/submissions/detail/899443720/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IRecentCounter Create() => new RecentCounter();

    private class RecentCounter : IRecentCounter
    {
        private readonly Queue<int> _queue = new();

        public int Ping(int t)
        {
            while (_queue.TryPeek(out var minTime) && minTime < t - 3000)
            {
                _queue.Dequeue();
            }

            _queue.Enqueue(t);

            return _queue.Count;
        }
    }
}
