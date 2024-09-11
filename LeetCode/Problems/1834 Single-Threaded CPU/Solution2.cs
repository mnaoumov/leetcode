using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1834_Single_Threaded_CPU;

/// <summary>
/// https://leetcode.com/submissions/detail/867234452/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] GetOrder(int[][] tasks) => GetOrderInternal(tasks);

    private static int[] GetOrderInternal(IEnumerable<int[]> arrays)
    {
        var pq = new PriorityQueue<Entry, Entry>();

        var index = 0;
        foreach (var array in arrays)
        {
            var entry = new Entry(array[0], array[1], index);
            pq.Enqueue(entry, entry);
            index++;
        }

        var result = new List<int>();

        while (pq.Count > 0)
        {
            var entry = pq.Dequeue();
            result.Add(entry.Index);
            var time = entry.EnqueueTime + entry.ProcessingTime;

            while (pq.TryPeek(out var nextEntry, out _) && nextEntry.EnqueueTime < time)
            {
                pq.Dequeue();
                nextEntry = nextEntry with { EnqueueTime = time };
                pq.Enqueue(nextEntry, nextEntry);
            }
        }

        return result.ToArray();
    }

    private record Entry(int EnqueueTime, int ProcessingTime, int Index) : IComparable<Entry>
    {
        public int CompareTo(Entry? other) => other == null ? 1 : (EnqueueTime, ProcessingTime, Index).CompareTo((other.EnqueueTime, other.ProcessingTime, other.Index));
    }
}
