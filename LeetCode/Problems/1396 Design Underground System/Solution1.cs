using JetBrains.Annotations;

namespace LeetCode.Problems._1396_Design_Underground_System;

/// <summary>
/// https://leetcode.com/submissions/detail/957979152/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IUndergroundSystem Create() => new UndergroundSystem();

    private class UndergroundSystem : IUndergroundSystem
    {
        private readonly Dictionary<int, (string startStation, int startTime)> _checkIns = new();
        private readonly Dictionary<(string startStation, string endStation), (int totalTime, int count)> _stats = new();

        public void CheckIn(int id, string stationName, int t)
        {
            var startTime = t;
            var startStation = stationName;
            _checkIns[id] = (startStation, startTime);
        }

        public void CheckOut(int id, string stationName, int t)
        {
            var (startStation, startTime) = _checkIns[id];
            var endStation = stationName;
            // ReSharper disable once InlineTemporaryVariable
            var endTime = t;
            var key = (startStation, endStation);
            var (totalTime, count) = _stats.GetValueOrDefault(key);
            _stats[key] = (totalTime + endTime - startTime, count + 1);
        }
    
        public double GetAverageTime(string startStation, string endStation)
        {
            var (totalTime, count) = _stats[(startStation, endStation)];
            return 1d * totalTime / count;
        }
    }
}
