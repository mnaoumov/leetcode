using JetBrains.Annotations;

namespace LeetCode.Problems._3191_Minimum_Operations_to_Make_Binary_Array_Elements_Equal_to_One_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-133/submissions/detail/1296748474/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var ans = 0;

        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            if (nums[i] != 0)
            {
                continue;
            }

            if (i + 2 >= n)
            {
                return -1;
            }

            ans++;

            for (var j = i; j < i + 3; j++)
            {
                nums[j] ^= 1;
            }
        }

        return ans;
    }
}
