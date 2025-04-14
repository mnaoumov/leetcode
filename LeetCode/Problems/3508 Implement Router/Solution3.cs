namespace LeetCode.Problems._3508_Implement_Router;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-444/problems/implement-router/submissions/1598079968/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public IRouter Create(int memoryLimit) => new Router(memoryLimit);

    private class Router : IRouter
    {
        private readonly int _memoryLimit;

        private readonly HashSet<(int source, int destination, int timestamp)> _set = new();
        private readonly Queue<(int source, int destination, int timestamp)> _queue = new();
        private readonly Dictionary<int, SortedSet<int>> _timestampsByDestination = new();
        private readonly Dictionary<(int destination, int timestamp), int> _prefixCountSums = new();
        private readonly Dictionary<int, int> _removeByDestinationCounts = new();

        public Router(int memoryLimit) => _memoryLimit = memoryLimit;

        public bool AddPacket(int source, int destination, int timestamp)
        {
            if (!_set.Add((source, destination, timestamp)))
            {
                return false;
            }

            _queue.Enqueue((source, destination, timestamp));

            if (_timestampsByDestination.TryAdd(destination, new SortedSet<int>()))
            {
                _prefixCountSums.TryAdd((destination, 0), 0);
            }

            var lastTimestamp = _timestampsByDestination[destination].Max;
            _prefixCountSums[(destination, timestamp)] = _prefixCountSums[(destination, lastTimestamp)] + 1;
            _timestampsByDestination[destination].Add(timestamp);

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
            _timestampsByDestination[oldest.destination].Remove(oldest.timestamp);
            _removeByDestinationCounts.TryAdd(oldest.destination, 0);
            _removeByDestinationCounts[oldest.destination]++;
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
            var timestamps = _timestampsByDestination.GetValueOrDefault(destination, new SortedSet<int>());
            var maxTimestamp = timestamps.GetViewBetween(0, endTime).Max;
            var minTimestamp = timestamps.GetViewBetween(0, startTime - 1).Max;
            var adjustedMaxTimestampCount = Math.Max(
                _prefixCountSums[(destination, maxTimestamp)] -
                _removeByDestinationCounts.GetValueOrDefault(destination, 0),
                0);
            var adjustedMinTimestampCount = Math.Max(
                _prefixCountSums[(destination, minTimestamp)] -
                _removeByDestinationCounts.GetValueOrDefault(destination, 0),
                0);
            return adjustedMaxTimestampCount - adjustedMinTimestampCount;
        }
    }
}
