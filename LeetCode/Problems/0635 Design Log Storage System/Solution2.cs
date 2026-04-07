using System.Globalization;

namespace LeetCode.Problems._0635_Design_Log_Storage_System;

/// <summary>
/// https://leetcode.com/problems/design-log-storage-system/submissions/1942647853/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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
            var parts = timestamp.Split(separator);
            var granularityObj = Granularity.Parse(granularity);
            var index = Granularity.All.IndexOf(granularityObj);
            for (var i = index + 1; i < parts.Length; i++)
            {
                var partGranularityObj = Granularity.All[i];
                var maxValueStr = partGranularityObj.MaxValue.ToString(CultureInfo.InvariantCulture);
                parts[i] = direction == Direction.Start
                    ? partGranularityObj.MinValue.ToString(CultureInfo.InvariantCulture).PadLeft(maxValueStr.Length, '0')
                    : maxValueStr;
            }

            return string.Join(separator, parts);
        }

        private enum Direction
        {
            Start,
            End
        }

        private sealed class Granularity
        {
            private static readonly Granularity Year = new() { MinValue = 2000, MaxValue = 2017 };
            private static readonly Granularity Month = new() { MinValue = 1, MaxValue = 12 };
            private static readonly Granularity Day = new() { MinValue = 1, MaxValue = 31 };
            private static readonly Granularity Hour = new() { MinValue = 0, MaxValue = 23 };
            private static readonly Granularity Minute = new() { MinValue = 0, MaxValue = 59 };
            private static readonly Granularity Second = new() { MinValue = 0, MaxValue = 59 };
            public static readonly Granularity[] All = new[] { Year, Month, Day, Hour, Minute, Second };


            public static Granularity Parse(string str)
            {
                return str switch
                {
                    "Year" => Year,
                    "Month" => Month,
                    "Day" => Day,
                    "Hour" => Hour,
                    "Minute" => Minute,
                    "Second" => Second,
                    _ => throw new InvalidOperationException()
                };
            }

            public int MaxValue { get; private init; }
            public int MinValue { get; private init; }
        }
    }
}
