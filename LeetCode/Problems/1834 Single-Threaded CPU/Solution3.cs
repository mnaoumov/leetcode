using JetBrains.Annotations;

namespace LeetCode._1834_Single_Threaded_CPU;

/// <summary>
/// https://leetcode.com/submissions/detail/867242975/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] GetOrder(int[][] tasks) => GetOrderInternal(tasks);

    private static int[] GetOrderInternal(IEnumerable<int[]> arrays)
    {
        var entriesQueue = new PriorityQueue<Entry, Entry>();
        var skippedEntriesQueue = new PriorityQueue<Entry, (int ProcessingTime, int Index)>();

        var index = 0;
        foreach (var array in arrays)
        {
            var entry = new Entry(array[0], array[1], index);
            entriesQueue.Enqueue(entry, entry);
            index++;
        }

        var result = new List<int>();
        var time = 1;

        while (entriesQueue.Count > 0 || skippedEntriesQueue.Count > 0)
        {
            var entry = skippedEntriesQueue.Count > 0 ? skippedEntriesQueue.Dequeue() : entriesQueue.Dequeue();
            result.Add(entry.Index);
            time = Math.Max(time, entry.EnqueueTime) + entry.ProcessingTime;

            while (entriesQueue.TryPeek(out var nextEntry, out _) && nextEntry.EnqueueTime <= time)
            {
                entriesQueue.Dequeue();
                skippedEntriesQueue.Enqueue(nextEntry, (nextEntry.ProcessingTime, nextEntry.Index));
            }
        }

        return result.ToArray();
    }

    private record Entry(int EnqueueTime, int ProcessingTime, int Index) : IComparable<Entry>
    {
        public int CompareTo(Entry? other) => other == null ? 1 : (EnqueueTime, ProcessingTime, Index).CompareTo((other.EnqueueTime, other.ProcessingTime, other.Index));
    }
}
