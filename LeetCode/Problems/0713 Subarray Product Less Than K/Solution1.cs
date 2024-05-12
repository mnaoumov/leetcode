using JetBrains.Annotations;

namespace LeetCode._0713_Subarray_Product_Less_Than_K;

/// <summary>
/// https://leetcode.com/submissions/detail/855114904/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1)
        {
            return 0;
        }

        var result = 0;

        var left = 0;
        var product = 1;

        for (var right = 0; right < nums.Length; right++)
        {
            product *= nums[right];

            while (product >= k && left < nums.Length)
            {
                product /= nums[left];
                left++;
            }

            result += right - left + 1;
        }

        return result;
    }
}
