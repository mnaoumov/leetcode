namespace LeetCode._0033_Search_in_Rotated_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/812942985/
/// </summary>
public class Solution : ISolution
{
    public int Search(int[] nums, int target)
    {
        var m = BinarySearch(nums, value => value < nums[0]);

        var k = nums.Length - m;

        const int notFoundIndex = -1;
        if (target >= nums[0])
        {
            var index = Array.BinarySearch(nums, 0, m, target);
            if (index >= 0)
            {
                return index;
            }
        }
        else if (k > 0)
        {
            var index = Array.BinarySearch(nums, m, k, target);
            if (index >= 0)
            {
                return index;
            }
        }

        return notFoundIndex;
    }

    private static int BinarySearch<T>(IReadOnlyList<T> sortedItems, Func<T, bool> predicate)
    {
        var left = 0;
        var right = sortedItems.Count;

        while (right - left > 1)
        {
            var mid = (left + right) / 2;

            if (predicate(sortedItems[mid]))
            {
                if (mid == left + 1)
                {
                    return mid;
                }

                right = mid + 1;
            }
            else
            {
                left = mid;
            }
        }

        return left + 1;
    }
}