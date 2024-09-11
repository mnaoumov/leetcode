namespace LeetCode.Problems._2187_Minimum_Time_to_Complete_Trips;

/// <summary>
/// https://leetcode.com/submissions/detail/910575508/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public long MinimumTime(int[] time, int totalTrips)
    {
        var low = 1L;
        var high = long.MaxValue;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            if (!IsEnoughTime(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;

        bool IsEnoughTime(long totalTime)
        {
            var tripsCount = 0L;

            foreach (var busTime in time)
            {
                tripsCount += totalTime / busTime;

                if (tripsCount >= totalTrips)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
