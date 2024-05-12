using JetBrains.Annotations;

namespace LeetCode.Problems._0283_Move_Zeroes;

/// <summary>
/// https://leetcode.com/submissions/detail/898890885/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void MoveZeroes(int[] nums)
    {
        var i = 0;
        var j = 0;

        while (true)
        {
            while (j < nums.Length && nums[j] == 0)
            {
                j++;
            }

            if (j == nums.Length)
            {
                break;
            }

            if (i < j)
            {
                nums[i] = nums[j];
                nums[j] = 0;
            }

            i++;
            j++;
        }
    }
}
