namespace LeetCode.Problems._1396_Design_Underground_System;

[PublicAPI]
public interface IUndergroundSystem
{
    void CheckIn(int id, string stationName, int t);
    void CheckOut(int id, string stationName, int t);
    double GetAverageTime(string startStation, string endStation);
}
