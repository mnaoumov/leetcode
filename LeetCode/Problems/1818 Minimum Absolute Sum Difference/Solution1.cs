using JetBrains.Annotations;

namespace LeetCode.Problems._1818_Minimum_Absolute_Sum_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/934396955/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
    {
        var sum = nums1.Zip(nums2, (num1, num2) => (num1, num2)).Sum(x => 0L + Math.Abs(x.num1 - x.num2));
        var sortedNums1 = nums1.OrderBy(num => num).ToArray();

        var n = nums1.Length;

        var result = sum;

        for (var i = 0; i < n; i++)
        {
            var previousItem = Math.Abs(nums1[i] - nums2[i]);

            var low = 0;
            var high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (sortedNums1[mid] >= nums2[i])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var newItem = int.MaxValue;

            if (low < n)
            {
                newItem = Math.Min(newItem, Math.Abs(sortedNums1[low] - nums2[i]));
            }

            if (low > 0)
            {
                newItem = Math.Min(newItem, Math.Abs(sortedNums1[low - 1] - nums2[i]));
            }

            result = Math.Min(result, sum - previousItem + newItem);

        }

        return (int) (result % 1_000_000_007);
    }
}
