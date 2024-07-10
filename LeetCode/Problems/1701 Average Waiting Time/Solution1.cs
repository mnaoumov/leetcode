using JetBrains.Annotations;

namespace LeetCode.Problems._1701_Average_Waiting_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/1314552351/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double AverageWaitingTime(int[][] customers)
    {
        var chefIdleTime = 0;
        var totalWaitingTime = 0L;

        foreach (var customer in customers)
        {
            var arrival = customer[0];
            var time = customer[1];
            chefIdleTime = Math.Max(chefIdleTime, arrival) + time;
            totalWaitingTime += chefIdleTime - arrival;
        }

        return 1d * totalWaitingTime / customers.Length;
    }
}
