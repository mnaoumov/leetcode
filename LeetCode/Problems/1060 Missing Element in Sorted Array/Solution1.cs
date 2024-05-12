using JetBrains.Annotations;

namespace LeetCode._1060_Missing_Element_in_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/942983899/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MissingElement(int[] nums, int k)
    {
        var low = nums[0] + k;
        var high = nums[^1] + k;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            var count = CountMissingBefore(mid);

            if (count < k)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return low;

        int CountMissingBefore(int num)
        {
            var index = Array.BinarySearch(nums, num);

            if (index < 0)
            {
                index = ~index - 1;
            }

            return num - nums[0] - index;
        }
    }
}
