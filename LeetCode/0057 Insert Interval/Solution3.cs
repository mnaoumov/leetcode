namespace LeetCode._0057_Insert_Interval;

/// <summary>
/// 
/// </summary>
public class Solution3 : ISolution
{
    public int[][] Insert(int[][] intervals, int[] newInterval) => Interval.ToArrays(Insert(Interval.FromArrays(intervals), Interval.FromArray(newInterval)));

    /// <summary>
    /// Was different signature
    /// </summary>
    /// <param name="intervals"></param>
    /// <param name="newInterval"></param>
    /// <returns></returns>
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
    {
        var result = intervals.ToList();

        var leftIndex = 0;
        var rightIndex = intervals.Count - 1;

        while (leftIndex <= rightIndex)
        {
            var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
            if (intervals[middleIndex].start >= newInterval.start)
            {
                rightIndex = middleIndex - 1;
            }
            else
            {
                leftIndex = middleIndex + 1;
            }
        }

        var newIntervalIndex = leftIndex;

        result.Insert(newIntervalIndex, newInterval);

        if (newIntervalIndex - 1 >= 0)
        {
            var previousInterval = result[newIntervalIndex - 1];
            if (previousInterval.end >= newInterval.start)
            {
                newInterval.start = previousInterval.start;
                newInterval.end = Math.Max(newInterval.end, previousInterval.end);
                result.RemoveAt(newIntervalIndex - 1);
                newIntervalIndex--;
            }
        }

        while (newIntervalIndex + 1 < result.Count)
        {
            var nextInterval = result[newIntervalIndex + 1];
            if (nextInterval.start <= newInterval.end)
            {
                newInterval.end = Math.Max(newInterval.end, nextInterval.end);
                result.RemoveAt(newIntervalIndex + 1);
            }
            else
            {
                break;
            }
        }

        return result;
    }
}
