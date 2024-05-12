using JetBrains.Annotations;

namespace LeetCode.Problems._0154_Find_Minimum_in_Rotated_Sorted_Array_II;

/// <summary>
/// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/submissions/848245079/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMin(int[] nums)
    {
        var left = 1;

        var right = nums.Length - 1;

        while (right >= 1 && nums[right] == nums[0])
        {
            right--;
        }

        while (left <= right)
        {
            var mid = (left + right) / 2;
            var num = nums[mid];

            if (num < nums[0])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left == nums.Length ? nums[0] : nums[left];
    }
}
