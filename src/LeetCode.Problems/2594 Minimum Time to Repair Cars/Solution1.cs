namespace LeetCode.Problems._2594_Minimum_Time_to_Repair_Cars;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-100/submissions/detail/917525138/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long RepairCars(int[] ranks, int cars)
    {
        var low = 1L;
        var high = 1L * ranks.Max() * cars * cars;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanRepair(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanRepair(long time)
        {
            var carsLeft = cars;

            foreach (var rank in ranks)
            {
                carsLeft -= (int) Math.Sqrt(1d * time / rank);

                if (carsLeft <= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
