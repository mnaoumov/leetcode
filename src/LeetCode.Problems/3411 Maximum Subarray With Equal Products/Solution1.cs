using System.Numerics;

namespace LeetCode.Problems._3411_Maximum_Subarray_With_Equal_Products;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-431/submissions/detail/1498000920/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxLength(int[] nums)
    {
        var n = nums.Length;

        for (var length = n; length >= 1; length--)
        {
            for (var i = 0; i <= n - length; i++)
            {
                BigInteger prod = 1;
                BigInteger lcm = 1;
                BigInteger gcd = 1;

                for (var j = i; j < i + length; j++)
                {
                    prod *= nums[j];
                    gcd = BigInteger.GreatestCommonDivisor(gcd, nums[j]);
                    lcm = lcm * nums[j] / BigInteger.GreatestCommonDivisor(lcm, nums[j]);
                }

                if (prod == lcm * gcd)
                {
                    return length;
                }
            }
        }

        return 0;
    }
}
