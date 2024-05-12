using JetBrains.Annotations;

namespace LeetCode.Problems._1396_Design_Underground_System;

[PublicAPI]
public interface IUndergroundSystem
{
    public void CheckIn(int id, string stationName, int t);
    public void CheckOut(int id, string stationName, int t);
    public double GetAverageTime(string startStation, string endStation);
}
