using JetBrains.Annotations;

namespace LeetCode.Problems._0004_Median_of_Two_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/828904106/
/// </summary>
[UsedImplicitly]
public class Solution13 : ISolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var a = nums1;
        var b = nums2;

        if (b.Length < a.Length)
        {
            (a, b) = (b, a);
        }

        var m = a.Length;
        var n = b.Length;
        var medianCount = (m + n + 1) / 2;

        var aLeftPartitionIndexRangeStart = 0;
        var aLeftPartitionIndexRangeEnd = m - 1;

        while (true)
        {
            var aLeftPartitionIndex =
                (int) Math.Floor((aLeftPartitionIndexRangeStart + aLeftPartitionIndexRangeEnd) / 2m);
            var aPartitionCount = aLeftPartitionIndex + 1;
            var bPartitionCount = medianCount - aPartitionCount;
            var bLeftPartitionIndex = bPartitionCount - 1;

            var (aLeftPartitionEndValue, aRightPartitionStartValue) =
                GetPartitionValues(a, aLeftPartitionIndex);
            var (bLeftPartitionEndValue, bRightPartitionStartValue) =
                GetPartitionValues(b, bLeftPartitionIndex);

            var isaPartitionValid = aLeftPartitionEndValue <= bRightPartitionStartValue;
            var isbPartitionValid = bLeftPartitionEndValue <= aRightPartitionStartValue;

            if (!isaPartitionValid)
            {
                aLeftPartitionIndexRangeEnd = aLeftPartitionIndex - 1;
            }
            else if (!isbPartitionValid)
            {
                aLeftPartitionIndexRangeStart = aLeftPartitionIndex + 1;
            }
            else
            {
                var leftPartitionValue = Math.Max(aLeftPartitionEndValue, bLeftPartitionEndValue);

                var isEven = (m + n) % 2 == 0;

                if (!isEven)
                {
                    return leftPartitionValue;
                }

                var rightPartitionValue = Math.Min(aRightPartitionStartValue, bRightPartitionStartValue);
                return (leftPartitionValue + rightPartitionValue) / 2;
            }
        }
    }

    private static (double leftPartitionEndValue, double rightPartitionStartValue) GetPartitionValues(IReadOnlyList<int> nums, int partitionIndex)
    {
        var leftPartitionEndValue = GetExtendedValue(nums, partitionIndex);
        var rightPartitionStartValue = GetExtendedValue(nums, partitionIndex + 1);
        return (leftPartitionEndValue, rightPartitionStartValue);
    }

    private static double GetExtendedValue(IReadOnlyList<int> nums, int index)
    {
        if (index < 0)
        {
            return double.NegativeInfinity;
        }

        if (index >= nums.Count)
        {
            return double.PositiveInfinity;
        }

        return nums[index];
    }
}
