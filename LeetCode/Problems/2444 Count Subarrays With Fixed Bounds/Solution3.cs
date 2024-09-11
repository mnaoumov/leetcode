
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2444_Count_Subarrays_With_Fixed_Bounds;

/// <summary>
/// https://leetcode.com/submissions/detail/823496471/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        if (minK > maxK)
        {
            return 0;
        }

        long result = 0;

        long countWithMinMax = 0;
        long countWithOnlyMin = 0;
        long countWithOnlyMax = 0;
        long countWithoutMinMax = 0;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            var value = nums[i];
            var isInRange = minK <= value && value <= maxK;
            var isMin = value == minK;
            var isMax = value == maxK;

            if (!isInRange)
            {
                countWithMinMax = 0;
                countWithOnlyMin = 0;
                countWithOnlyMax = 0;
                countWithoutMinMax = 0;
            }
            else
            {
                if (isMin && isMax)
                {
                    countWithMinMax += 1;
                }
                else if (isMin)
                {
                    countWithMinMax += countWithOnlyMax;
                    countWithOnlyMin += countWithoutMinMax + 1;
                    countWithOnlyMax = 0;
                    countWithoutMinMax = 0;
                }
                else if (isMax)
                {
                    countWithMinMax += countWithOnlyMin;
                    countWithOnlyMin = 0;
                    countWithOnlyMax += countWithoutMinMax + 1;
                    countWithoutMinMax = 0;
                }
                else
                {
                    countWithoutMinMax++;
                }

                result += countWithMinMax;
            }
        }

        return result;
    }
}
