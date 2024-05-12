using JetBrains.Annotations;

namespace LeetCode.Problems._0852_Peak_Index_in_a_Mountain_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/924034108/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PeakIndexInMountainArray(int[] arr)
    {
        var low = 0;
        var high = arr.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (mid + 1 < arr.Length && arr[mid] < arr[mid + 1])
            {
                low = mid + 1;
            }
            else if (mid >= 1 && arr[mid - 1] > arr[mid])
            {
                high = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return low;
    }
}
