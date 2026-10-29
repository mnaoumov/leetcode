namespace LeetCode.Problems._1437_Check_If_All_1_s_Are_at_Least_Length_K_Places_Away;

/// <summary>
/// https://leetcode.com/problems/check-if-all-1s-are-at-least-length-k-places-away/submissions/1831838119/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool KLengthApart(int[] nums, int k)
    {
        var lastOneIndex = -k - 1;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num != 1)
            {
                continue;
            }

            if (i - lastOneIndex <= k)
            {
                return false;
            }

            lastOneIndex = i;
        }

        return true;
    }
}
