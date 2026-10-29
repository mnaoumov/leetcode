namespace LeetCode.Problems._3508_Implement_Router;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-444/problems/implement-router/submissions/1598031207/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public IRouter Create(int memoryLimit) => new Router(memoryLimit);

    private class Router : IRouter
    {
        private readonly int _memoryLimit;

        private readonly HashSet<(int source, int destination, int timestamp)> _set = new();
        private readonly Queue<(int source, int destination, int timestamp)> _queue = new();
        private readonly Dictionary<int, SortedSet<(int destination, int source)>> _timestampsByDestination = new();

        public Router(int memoryLimit) => _memoryLimit = memoryLimit;

        public bool AddPacket(int source, int destination, int timestamp)
        {
            if (!_set.Add((source, destination, timestamp)))
            {
                return false;
            }

            _queue.Enqueue((source, destination, timestamp));
            _timestampsByDestination.TryAdd(destination, new SortedSet<(int destination, int source)>());
            _timestampsByDestination[destination].Add((timestamp, source));

            if (_set.Count > _memoryLimit)
            {
                Dequeue();
            }

            return true;
        }

        private (int source, int destination, int timestamp) Dequeue()
        {
            var oldest = _queue.Dequeue();
            _set.Remove(oldest);
            _timestampsByDestination[oldest.destination].Remove((oldest.timestamp, oldest.source));
            return oldest;
        }

        public int[] ForwardPacket()
        {
            if (_queue.Count == 0)
            {
                return Array.Empty<int>();
            }
            var oldest = Dequeue();
            return new[] { oldest.source, oldest.destination, oldest.timestamp };
        }

        public int GetCount(int destination, int startTime, int endTime)
        {
            const int minSource = int.MinValue;
            const int maxSource = int.MaxValue;

            var timestamps = _timestampsByDestination.GetValueOrDefault(destination, new SortedSet<(int destination, int source)>());
            return timestamps.GetViewBetween((startTime, minSource), (endTime, maxSource)).Count;
        }
    }
}
