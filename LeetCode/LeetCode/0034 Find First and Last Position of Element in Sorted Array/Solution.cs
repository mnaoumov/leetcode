namespace LeetCode._0034_Find_First_and_Last_Position_of_Element_in_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/812987415/
/// </summary>
public class Solution : ISolution
{
    public int[] SearchRange(int[] nums, int target)
    {
        const int notFoundIndex = -1;

        if (nums.Length == 0)
        {
            return new[] { notFoundIndex, notFoundIndex };
        }

        var left = 0;
        var right = nums.Length - 1;

        var minIndex = notFoundIndex;
        var maxIndex = notFoundIndex;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                minIndex = mid;
                right = mid - 1;
            }
        }

        if (minIndex == notFoundIndex)
        {
            return new[] { notFoundIndex, notFoundIndex };
        }

        left = minIndex;
        right = nums.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                maxIndex = mid;
                left = mid + 1;
            }
        }

        return new[] { minIndex, maxIndex };
    }
}