using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0004_Median_of_Two_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/807269846/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution08 : ISolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var m = nums1.Length;
        var n = nums2.Length;
        var medianCount = (m + n + 1) / 2;

        var nums1LeftPartitionIndexRangeStart = 0;
        var nums1LeftPartitionIndexRangeEnd = m - 1;

        while (true)
        {
            var nums1LeftPartitionIndex = (nums1LeftPartitionIndexRangeStart + nums1LeftPartitionIndexRangeEnd) / 2;
            var nums1PartitionCount = nums1LeftPartitionIndex + 1;
            var nums2PartionCount = medianCount - nums1PartitionCount;
            var nums2LeftPartitionIndex = nums2PartionCount - 1;

            var (nums1LeftPartitionEndValue, nums1RightPartitionStartValue) =
                GetPartitionValues(nums1, nums1LeftPartitionIndex);
            var (nums2LeftPartitionEndValue, nums2RightPartitionStartValue) =
                GetPartitionValues(nums2, nums2LeftPartitionIndex);

            var isNums1PartitionValid = nums1LeftPartitionEndValue <= nums2RightPartitionStartValue;
            var isNums2PartitionValid = nums2LeftPartitionEndValue <= nums1RightPartitionStartValue;

            if (!isNums1PartitionValid)
            {
                nums1LeftPartitionIndexRangeEnd = nums1LeftPartitionIndex - 1;
            }
            else if (!isNums2PartitionValid)
            {
                nums1LeftPartitionIndexRangeStart = nums1LeftPartitionIndex + 1;
            }
            else
            {
                var leftPartitionValue = Math.Max(nums1LeftPartitionEndValue, nums2LeftPartitionEndValue);

                var isEven = (m + n) % 2 == 0;

                if (isEven)
                {
                    var rightPartitionValue = Math.Min(nums1RightPartitionStartValue, nums2RightPartitionStartValue);

                    return (leftPartitionValue + rightPartitionValue) / 2;
                }
                else
                {
                    return leftPartitionValue;
                }
            }
        }
    }

    private static (double leftPartitionEndValue, double rightPartitionStartValue) GetPartitionValues(int[] nums, int partitionIndex)
    {
        var leftPartitionEndValue = GetExtendedValue(nums, partitionIndex);
        var rightPartitionStartValue = GetExtendedValue(nums, partitionIndex + 1);
        return (leftPartitionEndValue, rightPartitionStartValue);
    }

    private static double GetExtendedValue(int[] nums, int index)
    {
        if (index < 0)
        {
            return double.NegativeInfinity;
        }

        if (index >= nums.Length)
        {
            return double.PositiveInfinity;
        }

        return nums[index];
    }
}
