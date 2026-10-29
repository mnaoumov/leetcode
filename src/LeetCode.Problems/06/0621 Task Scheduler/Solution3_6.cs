// ReSharper disable All
#pragma warning disable
#pragma warning disable
namespace LeetCode.Problems._0621_Task_Scheduler;

/// <summary>
/// https://leetcode.com/submissions/detail/196716359/
/// https://leetcode.com/submissions/detail/818856201/
/// </summary>
[UsedImplicitly]
public class Solution3_6 : ISolution
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


        var sortedTaskCountPairs = new SortedSet<TaskCountPair>();

        foreach (var kvp in taskCounts)
        {
            sortedTaskCountPairs.Add(new TaskCountPair(kvp.Key, kvp.Value));
        }

        var result = 0;
        var queue = new Queue<char>(n);
        const char idleTask = ' ';
        var idleTaskPair = new TaskCountPair(idleTask, 0);

        for (var i = 0; i < n; i++)
        {
            queue.Enqueue(idleTask);
        }

        while (sortedTaskCountPairs.Any())
        {
            var maxCountTaskPair = sortedTaskCountPairs.FirstOrDefault(pair => !queue.Contains(pair.Task)) ?? idleTaskPair;

            queue.Enqueue(maxCountTaskPair.Task);
            queue.Dequeue();

            if (!maxCountTaskPair.Equals(idleTaskPair))
            {
                sortedTaskCountPairs.Remove(maxCountTaskPair);
                if (maxCountTaskPair.Count > 1)
                {
                    sortedTaskCountPairs.Add(new TaskCountPair(maxCountTaskPair.Task, maxCountTaskPair.Count - 1));
                }
            }

            result++;
        }

        return result;
    }

    private class TaskCountPair : IComparable<TaskCountPair>
    {
        public TaskCountPair(char task, int count)
        {
            Task = task;
            Count = count;
        }

        public char Task { get; }
        public int Count { get; }

        public bool Equals(TaskCountPair other)
        {
            return Task == other.Task && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            return obj is TaskCountPair other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Task.GetHashCode() * 397) ^ Count;
            }
        }

        public int CompareTo(TaskCountPair other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return ToTuple(this).CompareTo(ToTuple(other));
        }

        private static IComparable ToTuple(TaskCountPair pair)
        {
            return Tuple.Create(-pair.Count, pair.Task);
        }
    }
}
