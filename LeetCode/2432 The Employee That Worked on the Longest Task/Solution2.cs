using JetBrains.Annotations;

namespace LeetCode._2432_The_Employee_That_Worked_on_the_Longest_Task;

/// <summary>
/// https://leetcode.com/submissions/detail/891684518/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int HardestWorker(int n, int[][] logs)
    {
        var startTime = 0;

        var maxDuration = 0;
        var workerId = -1;

        foreach (var log in logs)
        {
            var endTime = log[1];
            var duration = endTime - startTime;

            if (duration > maxDuration || duration == maxDuration && log[0] < workerId)
            {
                maxDuration = duration;
                workerId = log[0];
            }

            startTime = endTime;
        }

        return workerId;
    }
}
