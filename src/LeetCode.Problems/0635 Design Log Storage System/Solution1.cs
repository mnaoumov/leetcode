namespace LeetCode.Problems._0635_Design_Log_Storage_System;

/// <summary>
/// https://leetcode.com/problems/design-log-storage-system/submissions/1942629544/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ILogSystem Create() => new LogSystem();

    private sealed class LogSystem : ILogSystem
    {
        private readonly SortedSet<string> _timestamps = new();
        private readonly Dictionary<string, int> _map = new();

        public void Put(int id, string timestamp)
        {
            _timestamps.Add(timestamp);
            _map[timestamp] = id;
        }

        public IList<int> Retrieve(string start, string end, string granularity)
        {
            start = Adjust(start, granularity, Direction.Start);
            end = Adjust(end, granularity, Direction.End);

            return _timestamps.GetViewBetween(start, end).Select(timestamp => _map[timestamp]).ToList();
        }

        private static string Adjust(string timestamp, string granularity, Direction direction)
        {
            const char separator = ':';
            var parts = timestamp.Split(separator).Select(int.Parse).ToArray();
            var granularityOptions = new[] { "Year", "Month", "Day", "Hour", "Minute", "Second" };
            var optionIndex = granularityOptions.IndexOf(granularity);
            for (var i = optionIndex + 1; i < parts.Length; i++)
            {
                parts[i] = direction == Direction.Start ? 0 : int.MaxValue;
            }

            return string.Join(separator, parts);
        }

        private enum Direction
        {
            Start,
            End
        }
    }
}
