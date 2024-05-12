using JetBrains.Annotations;

namespace LeetCode.Problems._1855_Maximum_Distance_Between_a_Pair_of_Values;

/// <summary>
/// https://leetcode.com/submissions/detail/915162018/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        var result = 0;

        for (var i = 0; i < Math.Min(nums1.Length, nums2.Length); i++)
        {
            var num1 = nums1[i];

            if (nums2[i] < num1)
            {
                continue;
            }

            var low = i;
            var high = nums2.Length - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (nums2[mid] >= num1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            result = Math.Max(result, low - i - 1);
        }

        return result;
    }
}
