namespace LeetCode.Problems._3914_Minimum_Operations_to_Make_Array_Non_Decreasing;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-499/problems/minimum-operations-to-make-array-non-decreasing/submissions/1988245334/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinOperations(int[] nums)
    {
        var ans = 0L;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                ans += nums[i - 1] - nums[i];
            }
        }

        return ans;
    }
}
