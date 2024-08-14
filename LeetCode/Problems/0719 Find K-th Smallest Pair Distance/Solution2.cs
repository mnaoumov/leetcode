using JetBrains.Annotations;

namespace LeetCode.Problems._0719_Find_K_th_Smallest_Pair_Distance;

/// <summary>
/// https://leetcode.com/submissions/detail/1354874531/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);
        var low = 0;
        var high = nums[^1] - nums[0];
        var n = nums.Length;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var count = 0;

            for (var i = 0; i < n; i++)
            {
                var nextIndex = BinarySearchLast(nums, i + 1, nums[i] + mid);
                count += nextIndex - i;
            }

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
    }

    private static int BinarySearchLast(int[] arr, int firstIndex, int value)
    {
        var low = firstIndex;
        var high = arr.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (arr[mid] > value)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return high;
    }
}
