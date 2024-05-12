using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0034_Find_First_and_Last_Position_of_Element_in_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/812973622/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int[] SearchRange(int[] nums, int target)
    {
        const int notFoundIndex = -1;

        if (nums.Length == 0)
        {
            return new[] { notFoundIndex, notFoundIndex };
        }

        var left = 0;
        var right = nums.Length;

        var minIndex = notFoundIndex;
        var maxIndex = notFoundIndex;

        while (left < right)
        {
            var mid = (left + right) / 2;

            if (nums[mid] == target)
            {
                if (mid == left)
                {
                    minIndex = mid;
                    if (minIndex == nums.Length - 1 || nums[minIndex + 1] > target)
                    {
                        maxIndex = mid;
                    }
                    break;
                }

                right = mid + 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        if (minIndex == notFoundIndex)
        {
            return new[] { notFoundIndex, notFoundIndex };
        }

        if (maxIndex == notFoundIndex)
        {
            left = minIndex;
            right = nums.Length;

            while (left < right)
            {
                var mid = (left + right) / 2;

                if (nums[mid] == target)
                {
                    left = mid;

                    if (mid == right - 1)
                    {
                        break;
                    }
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            maxIndex = left;
        }

        return new[] { minIndex, maxIndex };
    }
}
