namespace LeetCode.Problems._0704_Binary_Search;

/// <summary>
/// https://leetcode.com/submissions/detail/914692603/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Search(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var num = nums[mid];

            if (num == target)
            {
                return mid;
            }

            if (num < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }
}
