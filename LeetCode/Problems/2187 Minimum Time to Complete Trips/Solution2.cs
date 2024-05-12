using JetBrains.Annotations;

namespace LeetCode._2187_Minimum_Time_to_Complete_Trips;

/// <summary>
/// https://leetcode.com/submissions/detail/910555524/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long MinimumTime(int[] time, int totalTrips)
    {
        var low = 1L;
        var high = 1_000_000_000_000;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            if (GetTripsCount(mid) < totalTrips)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;

        long GetTripsCount(long time2) => time.Select(busTime => time2 / busTime).Sum();
    }
}
