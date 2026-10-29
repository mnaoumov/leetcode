namespace LeetCode.Problems._0539_Minimum_Time_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/1391597823/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMinDifference(IList<string> timePoints)
    {
        var timeSpans = timePoints.Select(TimeSpan.Parse).OrderBy(x => x).ToArray();
        var ans = (int) (timeSpans[0] + TimeSpan.FromHours(24) - timeSpans[^1]).TotalMinutes;
        var n = timeSpans.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var diff = (int) (timeSpans[i + 1] - timeSpans[i]).TotalMinutes;
            ans = Math.Min(ans, diff);
        }

        return ans;
    }
}
