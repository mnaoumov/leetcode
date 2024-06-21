using JetBrains.Annotations;

namespace LeetCode.Problems._0945_Minimum_Increment_to_Make_Array_Unique;

/// <summary>
/// https://leetcode.com/submissions/detail/1287543075/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinIncrementForUnique(int[] nums)
    {
        Array.Sort(nums);
        var ans = 0;
        var min = nums[0];

        foreach (var num in nums)
        {
            if (num < min)
            {
                ans += min - num;
                min++;
            }
            else
            {
                min = num + 1;
            }
        }

        return ans;
    }
}
