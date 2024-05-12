using JetBrains.Annotations;

namespace LeetCode.Problems._0162_Find_Peak_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/870934464/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left >> 1);

            var isGreaterThanLeft = mid == 0 || nums[mid] > nums[mid - 1];
            var isGreaterThanRight = mid == nums.Length - 1 || nums[mid] > nums[mid + 1];

            if (isGreaterThanLeft)
            {
                if (isGreaterThanRight)
                {
                    return mid;
                }
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return left;
    }
}
