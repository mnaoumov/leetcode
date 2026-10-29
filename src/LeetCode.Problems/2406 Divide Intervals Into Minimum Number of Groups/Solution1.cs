namespace LeetCode.Problems._2406_Divide_Intervals_Into_Minimum_Number_of_Groups;

/// <summary>
/// https://leetcode.com/submissions/detail/1419489163/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinGroups(int[][] intervals)
    {
        var intervalObjs = intervals.Select(Interval.FromArray).OrderBy(x => x.Left).ToArray();
        var groupEnds = new PriorityQueue<int, int>();
        groupEnds.Enqueue(0, 0);

        foreach (var interval in intervalObjs)
        {
            if (groupEnds.Peek() < interval.Left)
            {
                groupEnds.Dequeue();
            }

            groupEnds.Enqueue(interval.Right, interval.Right);
        }

        return groupEnds.Count;
    }

    private record Interval(int Left, int Right)
    {
        public static Interval FromArray(int[] arr) => new(arr[0], arr[1]);
    }
}
