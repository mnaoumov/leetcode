using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0081_Search_in_Rotated_Sorted_Array_II;

/// <summary>
/// https://leetcode.com/submissions/detail/822487962/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool Search(int[] nums, int target)
    {
        var m = FindRotateIndex();

        return Array.BinarySearch(nums, 0, m, target) >= 0 || Array.BinarySearch(nums, m, nums.Length - m, target) >= 0;

        int FindRotateIndex()
        {
            var left = 1;
            var right = nums.Length - 1;

            var last = nums[^1];

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
