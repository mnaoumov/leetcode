namespace LeetCode.Problems._2651_Calculate_Delayed_Arrival_Time;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-342/submissions/detail/938152183/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindDelayedArrivalTime(int arrivalTime, int delayedTime) => (arrivalTime + delayedTime) % 24;
}
