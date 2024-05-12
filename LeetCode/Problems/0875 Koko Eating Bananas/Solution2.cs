using JetBrains.Annotations;

namespace LeetCode._0875_Koko_Eating_Bananas;

/// <summary>
/// https://leetcode.com/submissions/detail/911178607/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var low = 1;
        var high = piles.Max();

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            if (piles.Sum(pile => 0L + (pile + mid - 1) / mid) > h)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;
    }
}
