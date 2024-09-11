using System.Numerics;

namespace LeetCode.Problems._2654_Minimum_Number_of_Operations_to_Make_All_Array_Elements_Equal_to_1;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-342/submissions/detail/938219046/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums)
    {
        var n = nums.Length;

        for (var i = 0; i < n - 1; i++)
        {
            var gcd = (int) BigInteger.GreatestCommonDivisor(nums[i], nums[i + 1]);

            if (gcd != 1)
            {
                continue;
            }

            var ans = i;

            for (var j = i; j < n; j++)
            {
                if (nums[j] != 1)
                {
                    ans++;
                }
            }

            return ans;
        }

        return -1;
    }
}
