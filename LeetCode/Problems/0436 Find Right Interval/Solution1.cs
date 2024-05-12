using JetBrains.Annotations;

namespace LeetCode.Problems._0436_Find_Right_Interval;

/// <summary>
/// https://leetcode.com/submissions/detail/936119437/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindRightInterval(int[][] intervals)
    {
        var sortedIntervals = intervals.Select((interval, index) => (start: interval[0], end: interval[1], index))
            .OrderBy(x => x.start)
            .ToArray();

        var n = sortedIntervals.Length;

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            var low = 0;
            var high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (sortedIntervals[mid].start < sortedIntervals[i].end)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            ans[sortedIntervals[i].index] = low == n ? -1 : sortedIntervals[low].index;
        }

        return ans;
    }
}
