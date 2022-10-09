namespace LeetCode._0034_Find_First_and_Last_Position_of_Element_in_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/198237160/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
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

        while (right - left > 1)
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
            else
            {
                left = middle;
            }
        }

        if (nums[left] != target)
        {
            return notFoundIndex;
        }

        if (!searchingFirstIndex && nums[right] == target)
        {
            return right;
        }

        return left;
    }
}