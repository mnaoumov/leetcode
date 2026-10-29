namespace LeetCode.Problems._1870_Minimum_Speed_to_Arrive_on_Time;

/// <summary>
/// https://leetcode.com/submissions/detail/914720735/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSpeedOnTime(int[] dist, double hour)
    {
        const int maxSpeed = 10_000_000;
        var low = 1;
        var high = maxSpeed;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (IsPossibleToArriveOnTime(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low > maxSpeed ? -1 : low;

        bool IsPossibleToArriveOnTime(int speed)
        {
            var totalTime = 0d;
            foreach (var trainDistance in dist)
            {
                totalTime = Math.Ceiling(totalTime);

                var time = 1d * trainDistance / speed;
                totalTime += time;

                if (totalTime > hour)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
