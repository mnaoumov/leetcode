using JetBrains.Annotations;

namespace LeetCode.Problems._2855_Minimum_Right_Shifts_to_Sort_the_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-113/submissions/detail/1050918218/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumRightShifts(IList<int> nums)
    {
        var n = nums.Count;
        var ans = 0;

        for (var i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                continue;
            }

            if (ans != 0 || nums[^1] >= nums[0])
            {
                return -1;
            }

            ans = n - i;
        }

        return ans;
    }
}
