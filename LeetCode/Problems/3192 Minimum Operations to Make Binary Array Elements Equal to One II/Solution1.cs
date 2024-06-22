using JetBrains.Annotations;

namespace LeetCode.Problems._3192_Minimum_Operations_to_Make_Binary_Array_Elements_Equal_to_One_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-133/submissions/detail/1296761020/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var ans = 0;
        var hasEvenFlips = true;

        foreach (var num in nums)
        {
            if (num == 1 == hasEvenFlips)
            {
                continue;
            }

            ans++;
            hasEvenFlips ^= true;
        }

        return ans;
    }
}
