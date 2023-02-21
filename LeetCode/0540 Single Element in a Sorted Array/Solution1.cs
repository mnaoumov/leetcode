using JetBrains.Annotations;

namespace LeetCode._0540_Single_Element_in_a_Sorted_Array;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SingleNonDuplicate(int[] nums)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low < high)
        {
            var mid = low + (high - low >> 1);

            if (mid % 2 == 1)
            {
                mid--;
            }

            if (nums[mid] != nums[mid + 1])
            {
                high = mid;
            }
            else
            {
                low = mid + 2;
            }
        }

        return nums[low];
    }
}
