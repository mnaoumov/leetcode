using JetBrains.Annotations;

namespace LeetCode._0621_Task_Scheduler;

/// <summary>
/// https://leetcode.com/submissions/detail/897260292/
/// </summary>
[UsedImplicitly]
public class Solution9 : ISolution
{
    public int LeastInterval(char[] tasks, int n)
    {
        var taskCountMap = tasks.GroupBy(task => task).ToDictionary(g => g.Key, g => g.Count());

        var pq = new PriorityQueue<char, int>();

        var idleTime = 0;

        foreach (var (task, count) in taskCountMap)
        {
            pq.Enqueue(task, -count);
        }

        var waitingQueue = new Queue<(char task, int timestamp)>();

        var timestamp = 0;

        while (pq.Count > 0 || waitingQueue.Count > 0)
        {
            if (pq.Count > 0)
            {
                var task = pq.Dequeue();
                taskCountMap[task]--;

                if (taskCountMap[task] > 0)
                {
                    waitingQueue.Enqueue((task, timestamp));
                }
            }
            else
            {
                idleTime++;
            }

            timestamp++;

            if (!waitingQueue.TryPeek(out var x) || timestamp - x.timestamp <= n)
            {
                continue;
            }

            waitingQueue.Dequeue();
            pq.Enqueue(x.task, -taskCountMap[x.task]);
        }

        return tasks.Length + idleTime;
    }
}
