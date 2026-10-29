namespace LeetCode.Problems._1665_Minimum_Initial_Energy_to_Finish_Tasks;

/// <summary>
/// https://leetcode.com/problems/minimum-initial-energy-to-finish-tasks/submissions/2000942163/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumEffort(int[][] tasks)
    {
        var taskObjs = tasks.Select(arr => new Task(arr[0], arr[1])).OrderByDescending(t => t.Minimum - t.Actual).ToArray();

        var low = 0;
        var high = taskObjs.Sum(t => t.Minimum);

        while (low <= high)
        {
            var mid = (low + high) / 2;

            if (CanFinishTasks(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanFinishTasks(int initialEnergy)
        {
            var energy = initialEnergy;

            foreach (var task in taskObjs)
            {
                if (energy < task.Minimum)
                {
                    return false;
                }

                energy -= task.Actual;
            }

            return true;
        }

    }

    private sealed record Task(int Actual, int Minimum);
}
