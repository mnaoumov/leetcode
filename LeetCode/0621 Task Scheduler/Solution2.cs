using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0621_Task_Scheduler;

/// <summary>
/// https://leetcode.com/submissions/detail/196705695/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LeastInterval(char[] tasks, int n)
    {
        var taskCounts = new Dictionary<char, int>();
        foreach (var task in tasks)
        {
            if (!taskCounts.ContainsKey(task))
            {
                taskCounts[task] = 0;
            }

            taskCounts[task]++;
        }


        var result = 0;
        var queue = new Queue<char>(n);
        const char idleTask = ' ';
        const int idleTaskFakeCount = 0;

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(idleTask);
        }

        int itemsLeft = tasks.Length;

        while (itemsLeft > 0)
        {
            var taskWithMaximumCount = taskCounts
                .Where(kvp => !queue.Contains(kvp.Key))
                .DefaultIfEmpty(new KeyValuePair<char, int>(idleTask, idleTaskFakeCount))
                .OrderByDescending(kvp => kvp.Value)
                .Select(kvp => kvp.Key)
                .FirstOrDefault();

            queue.Enqueue(taskWithMaximumCount);
            queue.Dequeue();

            if (taskWithMaximumCount != idleTask)
            {
                taskCounts[taskWithMaximumCount]--;
                if (taskCounts[taskWithMaximumCount] == 0)
                {
                    taskCounts.Remove(taskWithMaximumCount);
                }
                itemsLeft--;
            }

            result++;
        }

        return result;
    }
}
