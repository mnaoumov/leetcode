using JetBrains.Annotations;

namespace LeetCode._2226_Maximum_Candies_Allocated_to_K_Children;

/// <summary>
/// https://leetcode.com/submissions/detail/915417490/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumCandies(int[] candies, long k)
    {
        var low = 0;
        var high = 10_000_000;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanServeKids(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanServeKids(int candiesCountPerKid)
        {
            if (candiesCountPerKid == 0)
            {
                return true;
            }

            var servedKidsCount = 0L;
            foreach (var candiesCount in candies)
            {
                servedKidsCount += candiesCount / candiesCountPerKid;

                if (servedKidsCount >= k)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
