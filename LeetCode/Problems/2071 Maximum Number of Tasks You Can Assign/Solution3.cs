namespace LeetCode.Problems._2071_Maximum_Number_of_Tasks_You_Can_Assign;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-tasks-you-can-assign/submissions/1623087132/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        tasks = tasks.OrderByDescending(x => x).ToArray();
        workers = workers.OrderByDescending(x => x).ToArray();

        var n = tasks.Length;
        var m = workers.Length;
        var low = 0;
        var high = Math.Min(m, n);

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            if (CanAssign(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanAssign(int count)
        {
            var workersSet = new SortedSet<(int workerStrength, int index)>(workers.Select((workerStrength, index) => (workerStrength, index)));
            var pillsLeft = pills;

            for (var taskIndex = n - count; taskIndex < n; taskIndex++)
            {
                var task = tasks[taskIndex];

                if (task <= workersSet.Max.workerStrength)
                {
                    workersSet.Remove(workersSet.Max);
                    continue;
                }

                if (pillsLeft == 0)
                {
                    return false;
                }

                var filtered = workersSet.GetViewBetween((task - strength, 0), (int.MaxValue, int.MaxValue));
                if (filtered.Count == 0)
                {
                    return false;
                }

                workersSet.Remove(filtered.Min);
                pillsLeft--;
            }

            return true;
        }
    }
}