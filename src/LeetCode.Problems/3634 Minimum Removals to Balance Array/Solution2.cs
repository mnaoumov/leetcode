namespace LeetCode.Problems._3634_Minimum_Removals_to_Balance_Array;

/// <summary>
/// https://leetcode.com/problems/minimum-removals-to-balance-array/submissions/1910666548/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinRemoval(int[] nums, int k)
    {
        Array.Sort(nums);
        var j = 0;
        var n = nums.Length;
        var ans = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            while (j < n && nums[j] <= 1L * k * nums[i])
            {
                j++;
            }

            ans = Math.Min(ans, n - j + i);
        }

        return ans;
    }
}
