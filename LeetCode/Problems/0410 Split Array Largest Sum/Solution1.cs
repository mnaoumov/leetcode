using JetBrains.Annotations;

namespace LeetCode._0410_Split_Array_Largest_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/915146340/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SplitArray(int[] nums, int k)
    {
        var low = nums.Max();
        var high = nums.Sum();

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanSplit(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanSplit(int largestSum)
        {
            var sum = 0;
            var partsCount = 0;

            foreach (var num in nums)
            {
                sum += num;

                if (sum <= largestSum)
                {
                    continue;
                }

                partsCount++;
                sum = num;

                if (partsCount == k)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
