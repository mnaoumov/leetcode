using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0034_Find_First_and_Last_Position_of_Element_in_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/198238038/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var firstIndex = SearchRange(nums, target, searchingFirstIndex: true);
        var lastIndex = SearchRange(nums, target, searchingFirstIndex: false);

        return new[] { firstIndex, lastIndex };

    }

    private static int SearchRange(int[] nums, int target, bool searchingFirstIndex)
    {
        const int notFoundIndex = -1;

        if (nums.Length == 0 || nums[0] > target || nums[nums.Length - 1] < target)
        {
            return notFoundIndex;
        }

        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var middle = (left + right) / 2;
            var value = nums[middle];

            if (value < target)
            {
                left = middle + 1;
            }
            else if (value > target)
            {
                right = middle - 1;
            }
            else if (searchingFirstIndex)
            {
                right = middle;
            }
            else if (left != middle)
            {
                left = middle;
            }
            else if (nums[right] == target)
            {
                return right;
            }
            else
            {
                return left;
            }
        }

        if (nums[left] != target)
        {
            return notFoundIndex;
        }

        return left;
    }
}
