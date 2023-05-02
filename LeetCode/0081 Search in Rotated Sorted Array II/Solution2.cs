using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0081_Search_in_Rotated_Sorted_Array_II;

/// <summary>
/// https://leetcode.com/submissions/detail/822493422/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool Search(int[] nums, int target)
    {
        var m = FindRotateIndex();

        return Array.BinarySearch(nums, 0, m, target) >= 0 || Array.BinarySearch(nums, m, nums.Length - m, target) >= 0;

        int FindRotateIndex()
        {
            var left = 1;
            var right = nums.Length - 1;

            while (nums[right] == nums[0])
            {
                right--;
            }

            var last = nums[^1];

            if (nums[right] > nums[^1])
            {
                return right + 1;
            }

            while (left <= right)
            {
                var mid = (left + right) / 2;
                var value = nums[mid];

                if (value <= last)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
    }
}
