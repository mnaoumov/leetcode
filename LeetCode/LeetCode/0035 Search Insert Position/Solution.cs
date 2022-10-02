namespace LeetCode._0035_Search_Insert_Position;

/// <summary>
/// https://leetcode.com/submissions/detail/813031657/
/// </summary>
public class Solution : ISolution
{
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

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
                return mid;
            }
        }

        return left;
    }
}