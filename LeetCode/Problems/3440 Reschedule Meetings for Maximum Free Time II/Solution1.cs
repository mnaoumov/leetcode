namespace LeetCode.Problems._3440_Reschedule_Meetings_for_Maximum_Free_Time_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-149/problems/reschedule-meetings-for-maximum-free-time-ii/submissions/1527606662/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        var gaps = new List<int> { startTime[0] };
        var n = startTime.Length;

        for (var i = 0; i < n - 1; i++)
        {
            gaps.Add(startTime[i + 1] - endTime[i]);
        }

        gaps.Add(eventTime - endTime[^1]);

        var gapCounts = gaps.GroupBy(gap => gap).ToDictionary(g => g.Key, g => g.Count());
        var maxThreeGaps = gapCounts.Keys.OrderByDescending(gap => gap).Take(Math.Min(3, gapCounts.Count)).ToArray();

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var before = gaps[i];
            var after = gaps[i + 1];
            var length = endTime[i] - startTime[i];

            gapCounts[before]--;
            gapCounts[after]--;

            var maxAvailableGap = maxThreeGaps.FirstOrDefault(gap => gapCounts[gap] > 0);

            ans = maxAvailableGap >= length
                ? Math.Max(ans, before + after + length)
                : Math.Max(ans, before + after);

            gapCounts[before]++;
            gapCounts[after]++;
        }

        return ans;
    }
}
