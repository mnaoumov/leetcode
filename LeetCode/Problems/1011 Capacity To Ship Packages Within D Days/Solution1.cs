using JetBrains.Annotations;

namespace LeetCode.Problems._1011_Capacity_To_Ship_Packages_Within_D_Days;

/// <summary>
/// https://leetcode.com/submissions/detail/902638182/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShipWithinDays(int[] weights, int days)
    {
        var low = weights.Max();
        var high = weights.Sum();

        while (low < high)
        {
            var mid = low + (high - low >> 1);

            if (CanShip(mid))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanShip(int capacity)
        {
            var capacityAvailable = capacity;
            var daysAvailable = days;

            foreach (var weight in weights)
            {
                if (capacityAvailable < weight)
                {
                    capacityAvailable = capacity;
                    daysAvailable--;
                }

                if (daysAvailable <= 0)
                {
                    return false;
                }

                capacityAvailable -= weight;
            }

            return true;
        }
    }
}
