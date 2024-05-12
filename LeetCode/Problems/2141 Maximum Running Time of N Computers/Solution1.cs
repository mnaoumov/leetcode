using JetBrains.Annotations;

namespace LeetCode._2141_Maximum_Running_Time_of_N_Computers;

/// <summary>
/// https://leetcode.com/submissions/detail/915433679/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxRunTime(int n, int[] batteries)
    {
        var low = 0L;
        var high = batteries.Sum(b => (long) b) / n;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanRun(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanRun(long time)
        {
            if (time == 0L)
            {
                return true;
            }

            var requiredCapacity = time * n;

            foreach (var batteryTime in batteries)
            {
                requiredCapacity -= Math.Min(batteryTime, time);

                if (requiredCapacity <= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
