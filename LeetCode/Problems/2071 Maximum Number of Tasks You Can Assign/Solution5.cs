namespace LeetCode.Problems._2071_Maximum_Number_of_Tasks_You_Can_Assign;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-tasks-you-can-assign/submissions/1623095915/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        tasks = tasks.OrderByDescending(x => x).ToArray();
        workers = workers.OrderBy(x => x).ToArray();

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
            var workersList = workers.Skip(m - count).ToList();

            var pillsLeft = pills;

            for (var taskIndex = n - count; taskIndex < n; taskIndex++)
            {
                var task = tasks[taskIndex];

                if (task <= workersList[^1])
                {
                    workersList.RemoveAt(workersList.Count - 1);
                    continue;
                }

                if (pillsLeft == 0)
                {
                    return false;
                }

                var low2 = 0;
                var high2 = workersList.Count - 1;

                while (low2 <= high2)
                {
                    var mid = low2 + (high2 - low2 >> 1);

                    if (workersList[mid] >= task - strength)
                    {
                        high2 = mid - 1;
                    }
                    else
                    {
                        low2 = mid + 1;
                    }
                }

                if (low2 == workersList.Count)
                {
                    return false;
                }


                workersList.RemoveAt(low2);
                pillsLeft--;
            }

            return true;
        }
    }
}