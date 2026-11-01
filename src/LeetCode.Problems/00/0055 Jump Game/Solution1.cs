
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0055_Jump_Game;

/// <seealso href="https://leetcode.com/submissions/detail/198308227/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanJump(int[] nums)
    {
        int maxJump = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxJump)
            {
                return false;
            }

            maxJump = Math.Max(maxJump, i + nums[i]);
        }

        return true;
    }
}
