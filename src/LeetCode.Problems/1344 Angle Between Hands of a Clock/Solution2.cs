namespace LeetCode.Problems._1344_Angle_Between_Hands_of_a_Clock;

/// <summary>
/// https://leetcode.com/problems/angle-between-hands-of-a-clock/submissions/2036904195/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double AngleClock(int hour, int minutes)
    {
        const int fullCircleDegrees = 360;
        const int minutesPerFullCircle = 60;
        const int hoursPerFullCircle = 12;
        const int minutesPerHour = 60;

        if (hour == hoursPerFullCircle)
        {
            hour = 0;
        }

        var minutesArrowAngleDegrees = 1d * fullCircleDegrees / minutesPerFullCircle * minutes;
        var hoursArrowAngleDegrees =
            1d * fullCircleDegrees / hoursPerFullCircle * (hour + minutes * 1d / minutesPerHour);

        var diff = Math.Abs(minutesArrowAngleDegrees - hoursArrowAngleDegrees);
        var diffComplement = fullCircleDegrees - diff;
        return Math.Min(diff, diffComplement);
    }
}
