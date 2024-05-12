using JetBrains.Annotations;

namespace LeetCode._0253_Meeting_Rooms_II;

/// <summary>
/// https://leetcode.com/submissions/detail/954814833/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        var intervalObjs = intervals.Select(i => (start: i[0], end: i[1])).OrderBy(i => i.start).ToArray();

        var ans = 0;

        var endHeap = new PriorityQueue<int, int>();

        foreach (var (start, end) in intervalObjs)
        {
            while (endHeap.Count > 0 && start >= endHeap.Peek())
            {
                endHeap.Dequeue();
            }

            endHeap.Enqueue(end, end);
            ans = Math.Max(ans, endHeap.Count);
        }

        return ans;
    }
}
