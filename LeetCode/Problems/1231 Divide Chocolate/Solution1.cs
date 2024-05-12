using JetBrains.Annotations;

namespace LeetCode.Problems._1231_Divide_Chocolate;

/// <summary>
/// https://leetcode.com/submissions/detail/915125252/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximizeSweetness(int[] sweetness, int k)
    {
        var low = 1;
        var high = sweetness.Sum() / (k + 1);

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanSplit(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low - 1;

        bool CanSplit(int minTotalSweetness)
        {
            var totalSweetness = 0;
            var partsCount = 0;

            foreach (var chunkSweetness in sweetness)
            {
                totalSweetness += chunkSweetness;

                if (totalSweetness < minTotalSweetness)
                {
                    continue;
                }

                totalSweetness = 0;
                partsCount++;

                if (partsCount == k + 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
