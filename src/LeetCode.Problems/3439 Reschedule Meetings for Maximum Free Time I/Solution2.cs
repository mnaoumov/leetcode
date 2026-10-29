namespace LeetCode.Problems._3439_Reschedule_Meetings_for_Maximum_Free_Time_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-149/problems/reschedule-meetings-for-maximum-free-time-i/submissions/1527569839/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
    {
        var gaps = new List<int> { startTime[0] };
        var n = startTime.Length;

        for (var i = 0; i < n - 1; i++)
        {
            gaps.Add(startTime[i + 1] - endTime[i]);
        }

        gaps.Add(eventTime - endTime[^1]);

        var sum = gaps.Take(Math.Min(k + 1, gaps.Count)).Sum();
        var ans = sum;

        for (var i = 1; i < n - k + 1; i++)
        {
            sum -= gaps[i - 1];
            sum += gaps[i + k];
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}
