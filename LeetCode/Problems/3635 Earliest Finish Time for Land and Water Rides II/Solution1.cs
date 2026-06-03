namespace LeetCode.Problems._3635_Earliest_Finish_Time_for_Land_and_Water_Rides_II;

/// <summary>
/// https://leetcode.com/problems/earliest-finish-time-for-land-and-water-rides-ii/submissions/2020742031/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        var landActivities = landStartTime.Zip(landDuration,
            (startTime, duration) => new Activity(startTime, startTime + duration, duration)).ToArray();
        var waterActivities = waterStartTime.Zip(waterDuration,
            (startTime, duration) => new Activity(startTime, startTime + duration, duration)).ToArray();

        var earliestLandActivityEndTime = landActivities.Min(x => x.EndTime);
        var earliestFollowingWaterActivityEndTime = waterActivities.Select(x =>
            x.StartTime <= earliestLandActivityEndTime ? earliestLandActivityEndTime + x.Duration : x.EndTime).Min();

        var earliestWaterActivityEndTime = waterActivities.Min(x => x.EndTime);
        var earliestFollowingLandActivityEndTime = landActivities.Select(x =>
            x.StartTime <= earliestWaterActivityEndTime ? earliestWaterActivityEndTime + x.Duration : x.EndTime).Min();

        return Math.Min(earliestFollowingWaterActivityEndTime, earliestFollowingLandActivityEndTime);
    }

    private sealed record Activity(int StartTime, int EndTime, int Duration);
}
