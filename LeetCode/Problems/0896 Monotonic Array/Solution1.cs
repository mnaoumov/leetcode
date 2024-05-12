using JetBrains.Annotations;

namespace LeetCode._0896_Monotonic_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/930961807/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsMonotonic(int[] nums)
    {
        var n = nums.Length;

        var sign = 0;

        for (var i = 0; i < n - 1; i++)
        {
            var nextSign = Math.Sign(nums[i + 1] - nums[i]);

            if (nextSign == 0)
            {
                continue;
            }

            if (sign != 0 && sign != nextSign)
            {
                return false;
            }

            sign = nextSign;
        }

        return true;
    }
}
