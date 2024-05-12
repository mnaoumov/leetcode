using JetBrains.Annotations;

namespace LeetCode.Problems._1482_Minimum_Number_of_Days_to_Make_m_Bouquets;

/// <summary>
/// https://leetcode.com/submissions/detail/915440388/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDays(int[] bloomDay, int m, int k)
    {
        if (1L * m * k > bloomDay.Length)
        {
            return -1;
        }

        var low = 1;
        var high = bloomDay.Max();

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanMakeBouquets(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;


        bool CanMakeBouquets(int daysPassed)
        {
            var bloomedAdjacentFlowersCount = 0;
            var bouquetsCount = 0;

            foreach (var day in bloomDay)
            {
                if (day > daysPassed)
                {
                    bloomedAdjacentFlowersCount = 0;
                }
                else
                {
                    bloomedAdjacentFlowersCount++;

                    if (bloomedAdjacentFlowersCount < k)
                    {
                        continue;
                    }

                    bloomedAdjacentFlowersCount = 0;
                    bouquetsCount++;

                    if (bouquetsCount == m)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
