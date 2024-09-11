using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2589_Minimum_Time_to_Complete_All_Tasks;

/// <summary>
/// https://leetcode.com/submissions/detail/914057793/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int FindMinimumTime(int[][] tasks)
    {
        var orderedTasks = tasks.Select(task => (start: task[0], end: task[1], duration: task[2]))
            .OrderBy(task => task.end).ToArray();

        var sortedBusyTimes = new List<int>();
        var busyTimesSet = new HashSet<int>();

        foreach (var task in orderedTasks)
        {
            var duration = task.duration;

            var startIndex = sortedBusyTimes.BinarySearch(task.start);

            if (startIndex < 0)
            {
                startIndex = ~startIndex;
            }

            var endIndex = sortedBusyTimes.BinarySearch(task.end);

            if (endIndex < 0)
            {
                endIndex = ~endIndex - 1;
            }

            var usedDuration = startIndex <= endIndex ? endIndex - startIndex + 1 : 0;

            var time = task.end;

            while (usedDuration < duration)
            {
                if (!busyTimesSet.Add(time))
                {
                    continue;
                }

                var index = ~sortedBusyTimes.BinarySearch(time);
                sortedBusyTimes.Insert(index, time);
                usedDuration++;
                time--;
            }
        }

        return sortedBusyTimes.Count;
    }
}
