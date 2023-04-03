using JetBrains.Annotations;

namespace LeetCode._1608_Special_Array_With_X_Elements_Greater_Than_or_Equal_X;

/// <summary>
/// https://leetcode.com/submissions/detail/926936770/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;

        for (var j = 0; j < n; j++)
        {
            if (nums[j] + j >= n && (j == 0 || nums[j] > nums[j - 1] && n > nums[j - 1] + j))
            {
                return n - j;
            }
        }

        return -1;
    }
}
