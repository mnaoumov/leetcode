using JetBrains.Annotations;

namespace LeetCode._2009_Minimum_Number_of_Operations_to_Make_Array_Continuous;

/// <summary>
/// https://leetcode.com/submissions/detail/1071459227/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;
        nums = nums.Distinct().OrderBy(num => num).ToArray();
        var ans = n;

        for (var leftIndex = 0; leftIndex < nums.Length; leftIndex++)
        {
            var left = nums[leftIndex];
            var right = left + n - 1;
            var rightIndex = Array.BinarySearch(nums, right);

            if (rightIndex < 0)
            {
                rightIndex = ~rightIndex - 1;
            }

            ans = Math.Min(ans, n - 1 - rightIndex + leftIndex);
        }

        return ans;
    }
}
